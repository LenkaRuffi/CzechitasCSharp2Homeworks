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
        AccountingBook accountingBook = new AccountingBook();
        IEnumerable<Item> selectedItems;
        string pathToCommonAppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        string AppName = "ZjednodusenyUcetniDenik";
        string database = "databaze.csv";
        string pathToCsvDatabaseData;
        Filter RememberedFilter;

        public MainWindow()
        {
            InitializeComponent();
            pathToCsvDatabaseData = System.IO.Path.Combine(pathToCommonAppData, AppName, database);
            checkAndLoadDataIfDbDirectoryExistElseCreate();
            DataContext = accountingBook;
            ItemDataGrid.DataContext = accountingBook.AccountingBookItems;
            ItemDataGrid.ItemsSource = accountingBook.AccountingBookItems;
            SetSumTextBoxes();            
        }

        private void buttonFiltering_Click(object sender, RoutedEventArgs e)
        {
            int ItemTypeConvert = int.Parse(ItemTypeComboBox.SelectedValue.ToString());

            if (YearIntUpDown.Value != null && ItemTypeConvert == 0)
            {
                selectedItems =
                            from Item in accountingBook.AccountingBookItems
                            where Item.AccountingYear == YearIntUpDown.Value
                            select Item;
                ItemDataGrid.ItemsSource = selectedItems;
            }
            else if (YearIntUpDown.Value == null && ItemTypeConvert != 0)
            {                
                selectedItems =
                           from Item in accountingBook.AccountingBookItems
                           where (int)Item.ItemType == ItemTypeConvert
                           select Item;
                ItemDataGrid.ItemsSource = selectedItems;
            }
            else if (YearIntUpDown.Value != null && ItemTypeConvert != 0)
            {               
                selectedItems =
                              from Item in accountingBook.AccountingBookItems
                              where Item.AccountingYear == YearIntUpDown.Value
                              select Item;

                selectedItems =
                              from Item in selectedItems
                              where (int)Item.ItemType == ItemTypeConvert
                              select Item;

                ItemDataGrid.ItemsSource = selectedItems;
            }

            else
            {
                clearFilter();
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
                SaveItemsAsCSVHelper();
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
           /* string filename = "ucetniDenik.csv";
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string completePath = System.IO.Path.Combine(filePath, filename); */
            
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
                    using (StreamWriter sw = new StreamWriter(/*completePath*/ filename, false, Encoding.UTF8))
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

                       // MessageBox.Show("Položky byly exportovány");
                    }

                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            clearFilter();
            YearIntUpDown.Value = null;
            ItemTypeComboBox.SelectedValue = "0";

        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            FilteringWindow filterItemWindow = new FilteringWindow(accountingBook, RememberedFilter);
            filterItemWindow.ShowDialog();
            selectedItems = filterItemWindow.selectedItems;
            if(selectedItems != null)
            {
                ItemDataGrid.ItemsSource = selectedItems;
                FilterButton.Background = Brushes.Gray;
                RememberedFilter = filterItemWindow.ActualFilter;
                //ItemDataGrid.Items.Refresh();
            }
        }

        private void FilterClearButton_Click(object sender, RoutedEventArgs e)
        {
            clearFilter();
        }

        private void EditItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemDataGrid.SelectedItem != null)
            {
                EditItemWindow editItemWindow = new EditItemWindow((Item)ItemDataGrid.SelectedItem);
                editItemWindow.ShowDialog();
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

        private void LoadData()
        {
            
            CsvHelper.Configuration.CsvConfiguration csvConfiguration = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            using (StreamReader reader = new StreamReader(pathToCsvDatabaseData))
            using (CsvReader csv = new CsvReader(reader, csvConfiguration))
            {                
                var records = csv.GetRecords<Item>();
                List<Item> list = records.ToList();

                foreach(Item item in list)
                {
                    accountingBook.AccountingBookItems.Add(item);
                }

            }
        }

        private void checkAndLoadDataIfDbDirectoryExistElseCreate()
        {
            if (File.Exists(pathToCsvDatabaseData)) 
            {
                LoadData();
            }
            else
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(pathToCsvDatabaseData));
            }

        }

        private void SaveItemsAsCSVHelper()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(pathToCsvDatabaseData, false, Encoding.UTF8))
                using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(accountingBook.AccountingBookItems);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void clearFilter()
        {
            ItemDataGrid.ItemsSource = accountingBook.AccountingBookItems;
            selectedItems = null;
            SetSumTextBoxes();
            FilterButton.Background = Brushes.Transparent;
            RememberedFilter = null;
        }
    }
}
