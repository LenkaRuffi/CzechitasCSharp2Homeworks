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
    /// Interaction logic for EditItemWindow.xaml
    /// </summary>
    public partial class EditItemWindow : Window
    {       
        private Item selectedItem;
        private AccountingBook accountingBook;

        public EditItemWindow(Item selectedItem, AccountingBook accountingBook)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
            this.accountingBook = accountingBook;
          
            ItemTypeComboBox.SelectedValue = (int)selectedItem.ItemType;
            AmountDoubleUpDown.Value = selectedItem.Amount;
            InvoiceNumberTextBox.Text = selectedItem.InvoiceNumber;
            InvoiceDescriptionTextBox.Text = selectedItem.InvoiceDescription;
            ItemCategoryTextBox.Text = selectedItem.ItemCategory;
            InvoiceDateDatePicker.SelectedDate = selectedItem.InvoiceDate; 
            DueDateDatePicker.SelectedDate = selectedItem.DueDate; 
            PaymentDateDatePicker.SelectedDate = selectedItem.PaymentDate;
            CounterpartyNameTextBox.Text = selectedItem.CounterpartyName;
            CounterpartyIdentificateNumberTextBox.Text = selectedItem.CounterpartyIdentificateNumber;
            CounterpartyTaxIdentityNumberTextBox.Text = selectedItem.CounterpartyTaxIdentityNumber;
            CounterpartyAddressStreetTextBox.Text = selectedItem.CounterPartyAddress.Street;
            CounterpartyAddressZipCodeTextBox.Text = selectedItem.CounterPartyAddress.ZipCode;
            CounterpartyAddressTownTextBox.Text = selectedItem.CounterPartyAddress.Town;
            CounterpartyAddressStateTextBox.Text = selectedItem.CounterPartyAddress.State;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                //accountingBook.RemoveItem(selectedItem);
                bool itemOK = int.TryParse(ItemTypeComboBox.SelectedValue.ToString(), out int item);
                Address counterPartyAdress = new Address(CounterpartyAddressStreetTextBox.Text, CounterpartyAddressZipCodeTextBox.Text, CounterpartyAddressTownTextBox.Text, CounterpartyAddressStateTextBox.Text);
                selectedItem.EditWholeItem(InvoiceNumberTextBox.Text, InvoiceDescriptionTextBox.Text, CounterpartyNameTextBox.Text, counterPartyAdress, CounterpartyIdentificateNumberTextBox.Text, CounterpartyTaxIdentityNumberTextBox.Text, InvoiceDateDatePicker.SelectedDate, DueDateDatePicker.SelectedDate, PaymentDateDatePicker.SelectedDate, ItemCategoryTextBox.Text, (ItemType)item, AmountDoubleUpDown.Value);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

}
    }
}
