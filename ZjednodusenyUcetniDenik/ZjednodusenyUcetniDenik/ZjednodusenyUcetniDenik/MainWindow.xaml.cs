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
        Image logoFilter1 = new Image();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = accountingBook;
            ItemDataGrid.DataContext = accountingBook.AccountingBookItems;
            ItemDataGrid.ItemsSource = accountingBook.AccountingBookItems;
            //logoFilter1 = (Image)Resources.FindName("filter_icon"); //nefunguje
            //logoFilter = logoFilter1;
        }

        private void buttonFiltering_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Item> selectedItems =
            from Item in accountingBook.AccountingBookItems
            where Item.CounterpartyName == CounterpartyNameTextBox.Text
            select Item;

            // var ok = accountingBook.AccountingBookItems.Select(item => item.CounterpartyName == "x");
            ItemDataGrid.ItemsSource = selectedItems;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItemWindow addItemWindow = new AddItemWindow(accountingBook);
            addItemWindow.ShowDialog();            
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            if(ItemDataGrid.SelectedItem != null)
            {
                EditItemWindow editItemWindow = new EditItemWindow((Item)ItemDataGrid.SelectedItem);
                editItemWindow.ShowDialog();
                ItemDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nebyla vybrána položka k editaci.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Opravdu si přejete ukončit aplikaci?", "Ukončení aplikace", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.MainWindow.Close();
            }

        }

        private void MainWindowAccountingBook_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Opravdu si přejete ukončit aplikaci?", "Ukončení aplikace", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }

        }

        private void ExportItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Opravdu si přejete exportovat položky do csv?", "Export do csv", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DownloadItemsAsCSVHelper(); //pozor zatím exportuju vše a ještě nevytvářím csv
            }
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if(ItemDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Nebyla vybrána položka k odstranění.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Opravdu si přejete smazat vybranou položku? Smazání položky je nevratné.", "Upozornění", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                if (result == MessageBoxResult.Yes && ItemDataGrid.SelectedItem != null)
                {
                    accountingBook.RemoveItem((Item)ItemDataGrid.SelectedItem);
                }

                else
                {
                    MessageBox.Show("Položka nebyla odstraněna.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }

        }

        private void DownloadItemsAsCSVHelper()
        {
            string filename = "ucetniDenik.csv";
            byte[] bytes;

            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(stream, Encoding.UTF8))
                using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                  
                    csv.WriteRecords(accountingBook.AccountingBookItems);
                    sw.Flush();
                    bytes = stream.ToArray();
                    
                }
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            ItemDataGrid.ItemsSource = accountingBook.AccountingBookItems;

        }

        private void FilterItems_Click(object sender, RoutedEventArgs e)
        {
            FilteringWindow filterItemWindow = new FilteringWindow();
            filterItemWindow.ShowDialog();
            ItemDataGrid.Items.Refresh();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            FilteringWindow filterItemWindow = new FilteringWindow();
            filterItemWindow.ShowDialog();
            ItemDataGrid.Items.Refresh();

        }

        private void FilterClearButton_Click(object sender, RoutedEventArgs e)
        {
            ItemDataGrid.ItemsSource = accountingBook.AccountingBookItems;
        }
    }
}
