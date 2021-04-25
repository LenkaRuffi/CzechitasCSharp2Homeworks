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
        public Filter ActualFilter;

        public FilteringWindow(AccountingBook accountingBook, Filter rememberedFilter)
        {
            InitializeComponent();           
            this.accountingBook = accountingBook;
            ActualFilter = rememberedFilter;
            if(rememberedFilter != null)
            {
                setActualFilterToWindow();
            }
           
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
            setActualFilter();
            Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
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

        private void setActualFilter()
        {
            bool itemOK = int.TryParse(ItemTypeComboBox.SelectedValue.ToString(), out int item);
            Address counterPartyAdress = new Address(CounterpartyAddressStreetTextBox.Text, CounterpartyAddressZipCodeTextBox.Text, CounterpartyAddressTownTextBox.Text, CounterpartyAddressStateTextBox.Text);

            ActualFilter = new Filter(ItemTypeCheckBox.IsChecked, AmountCheckBox.IsChecked, InvoiceNumberCheckBox.IsChecked, InvoiceDescriptionCheckBox.IsChecked,
                ItemCategoryCheckBox.IsChecked, InvoiceDateCheckBox.IsChecked, DueDateCheckBox.IsChecked, PaymentDateCheckBox.IsChecked, YearCheckBox.IsChecked,
                CounterpartyNameCheckBox.IsChecked, CounterpartyIdentificateNumberCheckBox.IsChecked, CounterpartyTaxIdentityNumberCheckBox.IsChecked, CounterpartyStreetCheckBox.IsChecked,
                CounterpartyZipCodeCheckBox.IsChecked, CounterpartyAddressTownCheckBox.IsChecked, CounterpartyAddressStateCheckBox.IsChecked, InvoiceNumberTextBox.Text, InvoiceDescriptionTextBox.Text,
                CounterpartyNameTextBox.Text, counterPartyAdress, CounterpartyIdentificateNumberTextBox.Text, CounterpartyTaxIdentityNumberTextBox.Text, InvoiceDateDatePickerFrom.SelectedDate,
                DueDateDatePickerFrom.SelectedDate, PaymentDateDatePickerFrom.SelectedDate, ItemCategoryTextBox.Text, (ItemType)item, AmountDoubleUpDownFrom.Value, YearIntUpDownFrom.Value);
            
           //chybí vsechna pole do
        }

        private void setActualFilterToWindow()
        {
            ItemTypeCheckBox.IsChecked = ActualFilter.ItemTypeCheckBox;
            AmountCheckBox.IsChecked = ActualFilter.AmountCheckBox;
            InvoiceNumberCheckBox.IsChecked = ActualFilter.InvoiceNumberCheckBox;
            InvoiceDescriptionCheckBox.IsChecked = ActualFilter.InvoiceDescriptionCheckBox;
            ItemCategoryCheckBox.IsChecked = ActualFilter.ItemCategoryCheckBox;
            InvoiceDateCheckBox.IsChecked = ActualFilter.InvoiceDateCheckBox;
            DueDateCheckBox.IsChecked = ActualFilter.DueDateCheckBox;
            PaymentDateCheckBox.IsChecked = ActualFilter.PaymentDateCheckBox;
            YearCheckBox.IsChecked = ActualFilter.YearCheckBox;
            CounterpartyNameCheckBox.IsChecked = ActualFilter.CounterpartyNameCheckBox;
            CounterpartyIdentificateNumberCheckBox.IsChecked = ActualFilter.CounterpartyIdentificateNumberCheckBox;
            CounterpartyTaxIdentityNumberCheckBox.IsChecked = ActualFilter.CounterpartyTaxIdentityNumberCheckBox;
            CounterpartyStreetCheckBox.IsChecked = ActualFilter.CounterpartyStreetCheckBox;
            CounterpartyZipCodeCheckBox.IsChecked = ActualFilter.CounterpartyZipCodeCheckBox;
            CounterpartyAddressTownCheckBox.IsChecked = ActualFilter.CounterpartyAddressTownCheckBox;
            CounterpartyAddressStateCheckBox.IsChecked = ActualFilter.CounterpartyAddressStateCheckBox;
            InvoiceNumberTextBox.Text = ActualFilter.InvoiceNumber;

            setItemToActualFilterWindow();


        }

        private void setItemToActualFilterWindow()
        {
            ItemTypeComboBox.SelectedValue = (int)ActualFilter.ItemType;
            AmountDoubleUpDownFrom.Value = ActualFilter.Amount;
            InvoiceNumberTextBox.Text = ActualFilter.InvoiceNumber;
            InvoiceDescriptionTextBox.Text = ActualFilter.InvoiceDescription;
            ItemCategoryTextBox.Text = ActualFilter.ItemCategory;
            InvoiceDateDatePickerFrom.SelectedDate = ActualFilter.InvoiceDate;
            DueDateDatePickerFrom.SelectedDate = ActualFilter.DueDate;
            PaymentDateDatePickerFrom.SelectedDate = ActualFilter.PaymentDate;
            CounterpartyNameTextBox.Text = ActualFilter.CounterpartyName;
            CounterpartyIdentificateNumberTextBox.Text = ActualFilter.CounterpartyIdentificateNumber;
            CounterpartyTaxIdentityNumberTextBox.Text = ActualFilter.CounterpartyTaxIdentityNumber;
            CounterpartyAddressStreetTextBox.Text = ActualFilter.CounterPartyAddress.Street;
            CounterpartyAddressZipCodeTextBox.Text = ActualFilter.CounterPartyAddress.ZipCode;
            CounterpartyAddressTownTextBox.Text = ActualFilter.CounterPartyAddress.Town;
            CounterpartyAddressStateTextBox.Text = ActualFilter.CounterPartyAddress.State;
            YearIntUpDownFrom.Value = ActualFilter.AccountingYear;
        }
    }
}
