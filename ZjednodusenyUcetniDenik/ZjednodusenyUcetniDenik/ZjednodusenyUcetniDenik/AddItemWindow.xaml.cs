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
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        private AccountingBook accountingBook;
        
        public AddItemWindow(AccountingBook accountingBook)
        {
            InitializeComponent();
            this.accountingBook = accountingBook;
            YearIntUpDown.Value = DateTime.Today.Year;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {              
                bool itemOK = int.TryParse(ItemTypeComboBox.SelectedValue.ToString(), out int item);
                Address counterPartyAdress = new Address(CounterpartyAddressStreetTextBox.Text, CounterpartyAddressZipCodeTextBox.Text, 
                    CounterpartyAddressTownTextBox.Text, CounterpartyAddressStateTextBox.Text);
                                               
                accountingBook.AddItem(InvoiceNumberTextBox.Text, InvoiceDescriptionTextBox.Text, CounterpartyNameTextBox.Text, counterPartyAdress, 
                    CounterpartyIdentificateNumberTextBox.Text, CounterpartyTaxIdentityNumberTextBox.Text, InvoiceDateDatePicker.SelectedDate, 
                    DueDateDatePicker.SelectedDate, PaymentDateDatePicker.SelectedDate, ItemCategoryTextBox.Text, (ItemType)item, AmountDoubleUpDown.Value, 
                    YearIntUpDown.Value);
                Close();             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
