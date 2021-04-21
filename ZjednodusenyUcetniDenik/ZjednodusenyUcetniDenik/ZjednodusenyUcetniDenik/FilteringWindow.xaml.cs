using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ZjednodusenyUcetniDenik
{
    /// <summary>
    /// Interaction logic for FilteringWindow.xaml
    /// </summary>
    public partial class FilteringWindow : Window
    {
        private AccountingBook accountingBook;
        public IEnumerable<Item> selectedItems;

        public FilteringWindow(AccountingBook accountingBook)
        {
            InitializeComponent();
            this.accountingBook = accountingBook;
        }

        public void FilteringItems() //na lekci by mel vitek vysvetlit linq, tak aby se daly vrstvit dotazy, takze bych pak podle ifu to mela byt schopna vyfiltrovat do ienumerable
        {
            if (CounterpartyNameCheckBox.IsChecked == true)
            {
                selectedItems =
                from Item in accountingBook.AccountingBookItems
                where Item.CounterpartyName == CounterpartyNameTextBox.Text
                select Item;
            }

        }

        private void buttonFiltering_Click(object sender, RoutedEventArgs e)
        {
            FilteringItems();
            Close();
        }

        /*public void Test(CheckBox checkBox, TextBox textBox )
        {
            if(checkBox.IsChecked == true)
            {
                selectedItems =
              from Item in accountingBook.AccountingBookItems
              where Item.CounterpartyName == textBox.Text
              select Item;
            }
          
        }*/
    }
}
