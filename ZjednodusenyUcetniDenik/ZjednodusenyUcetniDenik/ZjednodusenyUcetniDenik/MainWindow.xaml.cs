using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CsvHelper;

namespace ZjednodusenyUcetniDenik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccountingBook accountingBook;
        IEnumerable<Item> selectedItems;       
        Filter RememberedFilter;
        LoadAndSaveData LoadingAndSaving;

        public MainWindow()
        {
            InitializeComponent();
            accountingBook = new AccountingBook();
            LoadingAndSaving = new LoadAndSaveData();            
            LoadingAndSaving.CheckAndLoadDataIfDbDirectoryExistElseCreate();
            accountingBook = LoadingAndSaving.workingAccountingBook;
            DataContext = accountingBook;
            ItemDataGrid.DataContext = accountingBook.AccountingBookItems;
            ItemDataGrid.ItemsSource = accountingBook.AccountingBookItems;
            SetSumTextBoxes();            
        }

        private void buttonFiltering_Click(object sender, RoutedEventArgs e)
        {
            int ItemTypeConvert = int.Parse(ItemTypeComboBox.SelectedValue.ToString());
            bool itemsWasFiltered = false;

            if (selectedItems == null)
            {
                selectedItems = accountingBook.AccountingBookItems;
            }

            if (ItemTypeConvert != 0)
            {                
                selectedItems = selectedItems.Where(i => (int)i.ItemType == ItemTypeConvert).Select(i => i);
                itemsWasFiltered = true;
            }
            if (YearIntUpDown.Value != null) 
            { 
                selectedItems = selectedItems.Where(i => i.AccountingYear == YearIntUpDown.Value).Select(i => i); 
                itemsWasFiltered = true; 
            }            

            if (!itemsWasFiltered)
            {
                selectedItems = null;
                ClearFilter();
            }
            else
            {
                ItemDataGrid.ItemsSource = selectedItems;
            }
            
            SetSumTextBoxes();   
        }

       
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
           Application.Current.MainWindow.Close();
        }

        private void MainWindowAccountingBook_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Opravdu si přejete ukončit aplikaci?", "Ukončení aplikace", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                LoadingAndSaving.SaveItemsAsCSVHelper(accountingBook);
            }

        }

        private void ExportItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Opravdu si přejete exportovat položky do csv?", "Export do csv", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DownloadItemsAsCSVHelper();               
            }
        }        

        private void DownloadItemsAsCSVHelper()
        {           
            try
            {
                Microsoft.Win32.SaveFileDialog saveDialog = new Microsoft.Win32.SaveFileDialog()                
                {                    
                    Filter = "Csv(*.csv)|.csv|All(*.*)|*"                   
                };

                Nullable<bool> result = saveDialog.ShowDialog();
                
                string filename;

                if (result == true)
                {
                    
                    filename = saveDialog.FileName;
                    using (StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8))
                    using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
                    {
                        if (selectedItems == null)
                        {
                            csv.WriteRecords(accountingBook.AccountingBookItems);
                        }
                        else
                        {
                            csv.WriteRecords(selectedItems);
                        }
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFilter();
        }

        private void FilterButtonInToolBar_Click(object sender, RoutedEventArgs e)
        {
            FilteringWindow filterItemWindow = new FilteringWindow(accountingBook, RememberedFilter, selectedItems);
            filterItemWindow.ShowDialog();
            selectedItems = filterItemWindow.SelectedItems;
            SetSumTextBoxes();
            if(selectedItems != null)
            {
                ItemDataGrid.ItemsSource = selectedItems;
                FilterButton.Background = Brushes.Gray;
                RememberedFilter = filterItemWindow.ActualFilter;               
            }
        }

        private void FilterClearButtonInToolBar_Click(object sender, RoutedEventArgs e)
        {
            ClearFilter();
        }

        private void EditItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemDataGrid.SelectedItem != null)
            {
                EditItemWindow editItemWindow = new EditItemWindow((Item)ItemDataGrid.SelectedItem);
                editItemWindow.ShowDialog();
                LoadingAndSaving.SaveItemsAsCSVHelper(accountingBook);
                ItemDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nebyla vybrána položka k editaci.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            SetSumTextBoxes();
        }

        private void AddNewItemButton_Click(object sender, RoutedEventArgs e)
        {
            AddItemWindow addItemWindow = new AddItemWindow(accountingBook);
            addItemWindow.ShowDialog();
            LoadingAndSaving.SaveItemsAsCSVHelper(accountingBook);
            SetSumTextBoxes();
        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Nebyla vybrána položka k odstranění.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Opravdu si přejete smazat vybranou položku? Smazání položky je nevratné.", "Upozornění", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                if (result == MessageBoxResult.Yes && ItemDataGrid.SelectedItem != null)
                {
                    accountingBook.RemoveItem((Item)ItemDataGrid.SelectedItem);
                    LoadingAndSaving.SaveItemsAsCSVHelper(accountingBook);
                    if (selectedItems != null)
                    {
                        selectedItems = selectedItems.Where(i => i != ItemDataGrid.SelectedItem).ToList();
                        ItemDataGrid.ItemsSource = selectedItems;
                    }
                }

                else
                {
                    MessageBox.Show("Položka nebyla odstraněna.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
                }  
            }

            SetSumTextBoxes();
        }

        private void SetSumTextBoxes()
        {
           if(selectedItems != null)
            {
                IncomeSumTextBox.Text = selectedItems.Where(a => a.ItemType == ItemType.Příjem).Sum(a => a.Amount).ToString();
                CostSumTextBox.Text = selectedItems.Where(a => a.ItemType == ItemType.Výdaj).Sum(a => a.Amount).ToString();
            }
           else
            {
                IncomeSumTextBox.Text = accountingBook.SumIncome.ToString();
                CostSumTextBox.Text = accountingBook.SumCost.ToString();
            }          
        }

        private void ClearFilter()
        {
            ItemDataGrid.ItemsSource = accountingBook.AccountingBookItems;
            selectedItems = null;
            SetSumTextBoxes();
            FilterButton.Background = Brushes.Transparent;
            RememberedFilter = null;
            YearIntUpDown.Value = null;
            ItemTypeComboBox.SelectedValue = "0";
        }
    }
}
