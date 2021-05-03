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
        public IEnumerable<Item> SelectedItems;
        public Filter ActualFilter;

        public FilteringWindow(AccountingBook accountingBook, Filter rememberedFilter, IEnumerable<Item> selectedItems)
        {
            InitializeComponent();           
            this.accountingBook = accountingBook;
            this.SelectedItems = selectedItems;
            ActualFilter = rememberedFilter;
            if(rememberedFilter != null)
            {
                SetActualFilterToWindow();
            }           
        }

        public void FilteringItems() 
        {
            if(SelectedItems == null)
            {
                SelectedItems = accountingBook.AccountingBookItems;
            }            
            bool itemsWasFiltered = false;
           
            if (ItemTypeCheckBox.IsChecked == true) 
            {
                int selectedValue = int.Parse(ItemTypeComboBox.SelectedValue.ToString());               
                SelectedItems = SelectedItems.Where(i => (int)i.ItemType == selectedValue).Select(i => i);
                itemsWasFiltered = true;
            }
            if (AmountCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.Amount >= IfNullReturnMinDouble(AmountDoubleUpDownFrom.Value) && i.Amount <= IfNullReturnMaxDouble(AmountDoubleUpDownTo.Value)).Select(i => i); itemsWasFiltered = true; }
            if (InvoiceNumberCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.InvoiceNumber.Trim().Equals(InvoiceNumberTextBox.Text.Trim())).Select(i => i); itemsWasFiltered = true; }
            if (InvoiceDescriptionCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.InvoiceDescription.Trim().Equals(InvoiceDescriptionTextBox.Text.Trim())).Select(i => i); itemsWasFiltered = true; }
            if (ItemCategoryCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.ItemCategory.Trim().Equals(ItemCategoryTextBox.Text.Trim())).Select(i => i); itemsWasFiltered = true; }
            if (InvoiceDateCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.InvoiceDate >= IfNullReturnMinDate(InvoiceDateDatePickerFrom.SelectedDate) && i.InvoiceDate <= IfNullReturnMaxDate(InvoiceDateDatePickerTo.SelectedDate)).Select(i => i); itemsWasFiltered = true; }
            if (DueDateCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.DueDate >= IfNullReturnMinDate(DueDateDatePickerFrom.SelectedDate) && i.DueDate <= IfNullReturnMaxDate(DueDateDatePickerTo.SelectedDate)).Select(i => i); itemsWasFiltered = true; }
            if (PaymentDateCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.PaymentDate >= IfNullReturnMinDate(PaymentDateDatePickerFrom.SelectedDate) && i.PaymentDate <= IfNullReturnMaxDate(PaymentDateDatePickerTo.SelectedDate)).Select(i => i); itemsWasFiltered = true; }
            if (YearCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.AccountingYear >= IfNullReturnMinDouble(YearIntUpDownFrom.Value) && i.AccountingYear <= IfNullReturnMaxDouble(YearIntUpDownTo.Value)).Select(i => i); itemsWasFiltered = true; }
            if (CounterpartyNameCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.CounterpartyName.Trim().Equals(CounterpartyNameTextBox.Text.Trim())).Select(i => i); itemsWasFiltered = true; }
            if (CounterpartyIdentificateNumberCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.CounterpartyIdentificateNumber.Trim().Equals(CounterpartyIdentificateNumberTextBox.Text.Trim())).Select(i => i); itemsWasFiltered = true; }
            if (CounterpartyTaxIdentityNumberCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.CounterpartyTaxIdentityNumber.Trim().Equals(CounterpartyTaxIdentityNumberTextBox.Text.Trim())).Select(i => i); itemsWasFiltered = true; }
            if (CounterpartyStreetCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.CounterPartyAddress.Street.Trim().Equals(CounterpartyAddressStreetTextBox.Text.Trim())).Select(i => i); itemsWasFiltered = true; }
            if (CounterpartyZipCodeCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.CounterPartyAddress.ZipCode.Trim().Equals(CounterpartyAddressZipCodeTextBox.Text.Trim())).Select(i => i); itemsWasFiltered = true; }
            if (CounterpartyAddressTownCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.CounterPartyAddress.Town.Trim().Equals(CounterpartyAddressTownTextBox.Text.Trim())).Select(i => i); itemsWasFiltered = true; }
            if (CounterpartyAddressStateCheckBox.IsChecked == true) { SelectedItems = SelectedItems.Where(i => i.CounterPartyAddress.State.Trim().Equals(CounterpartyAddressStateTextBox.Text.Trim())).Select(i => i); itemsWasFiltered = true; }
            
            if(!itemsWasFiltered)
            {
                SelectedItems = null;
            }          

        }

        private void ButtonFiltering_Click(object sender, RoutedEventArgs e)
        {
            FilteringItems();
            SetActualFilter();
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SetActualFilter()
        {
            bool itemOK = int.TryParse(ItemTypeComboBox.SelectedValue.ToString(), out int item);
            Address counterPartyAdress = new Address(CounterpartyAddressStreetTextBox.Text, CounterpartyAddressZipCodeTextBox.Text, CounterpartyAddressTownTextBox.Text, CounterpartyAddressStateTextBox.Text);

            ActualFilter = new Filter(ItemTypeCheckBox.IsChecked, AmountCheckBox.IsChecked, InvoiceNumberCheckBox.IsChecked, InvoiceDescriptionCheckBox.IsChecked,
                ItemCategoryCheckBox.IsChecked, InvoiceDateCheckBox.IsChecked, DueDateCheckBox.IsChecked, PaymentDateCheckBox.IsChecked, YearCheckBox.IsChecked,
                CounterpartyNameCheckBox.IsChecked, CounterpartyIdentificateNumberCheckBox.IsChecked, CounterpartyTaxIdentityNumberCheckBox.IsChecked, CounterpartyStreetCheckBox.IsChecked,
                CounterpartyZipCodeCheckBox.IsChecked, CounterpartyAddressTownCheckBox.IsChecked, CounterpartyAddressStateCheckBox.IsChecked, InvoiceNumberTextBox.Text, InvoiceDescriptionTextBox.Text,
                CounterpartyNameTextBox.Text, counterPartyAdress, CounterpartyIdentificateNumberTextBox.Text, CounterpartyTaxIdentityNumberTextBox.Text, InvoiceDateDatePickerFrom.SelectedDate,
                DueDateDatePickerFrom.SelectedDate, PaymentDateDatePickerFrom.SelectedDate, ItemCategoryTextBox.Text, (ItemType)item, AmountDoubleUpDownFrom.Value, YearIntUpDownFrom.Value, AmountDoubleUpDownTo.Value,
                InvoiceDateDatePickerTo.SelectedDate, DueDateDatePickerTo.SelectedDate, PaymentDateDatePickerTo.SelectedDate, YearIntUpDownTo.Value);           
        }

        private void SetActualFilterToWindow()
        {           
            SetCheckboxToActualFilterWindow();
            SetItemToActualFilterWindow();
        }

        private void SetCheckboxToActualFilterWindow()
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
        }
        

        private void SetItemToActualFilterWindow()
        {
            ItemTypeComboBox.SelectedValue = (int)ActualFilter.ItemType;
            AmountDoubleUpDownFrom.Value = ActualFilter.Amount;
            AmountDoubleUpDownTo.Value = ActualFilter.AmountTo;
            InvoiceNumberTextBox.Text = ActualFilter.InvoiceNumber;
            InvoiceDescriptionTextBox.Text = ActualFilter.InvoiceDescription;
            ItemCategoryTextBox.Text = ActualFilter.ItemCategory;
            InvoiceDateDatePickerFrom.SelectedDate = ActualFilter.InvoiceDate;
            InvoiceDateDatePickerTo.SelectedDate = ActualFilter.InvoiceDateTo;
            DueDateDatePickerFrom.SelectedDate = ActualFilter.DueDate;
            DueDateDatePickerTo.SelectedDate = ActualFilter.DueDateTo;
            PaymentDateDatePickerFrom.SelectedDate = ActualFilter.PaymentDate;
            PaymentDateDatePickerTo.SelectedDate = ActualFilter.PaymentDateTo;
            CounterpartyNameTextBox.Text = ActualFilter.CounterpartyName;
            CounterpartyIdentificateNumberTextBox.Text = ActualFilter.CounterpartyIdentificateNumber;
            CounterpartyTaxIdentityNumberTextBox.Text = ActualFilter.CounterpartyTaxIdentityNumber;
            CounterpartyAddressStreetTextBox.Text = ActualFilter.CounterPartyAddress.Street;
            CounterpartyAddressZipCodeTextBox.Text = ActualFilter.CounterPartyAddress.ZipCode;
            CounterpartyAddressTownTextBox.Text = ActualFilter.CounterPartyAddress.Town;
            CounterpartyAddressStateTextBox.Text = ActualFilter.CounterPartyAddress.State;
            YearIntUpDownFrom.Value = ActualFilter.AccountingYear;
            YearIntUpDownTo.Value = ActualFilter.AccountingYearTo;

        }

        private double? IfNullReturnMaxDouble (double? value)
        {
            return value == null ? double.MaxValue : value;
        }

        private double? IfNullReturnMinDouble(double? value)
        {
            return value == null ? double.MinValue : value;
        }

        private DateTime? IfNullReturnMaxDate(DateTime? value)
        {
            return value == null ? DateTime.MaxValue : value;
        }


        private DateTime? IfNullReturnMinDate(DateTime? value)
        {
            return value == null ? DateTime.MinValue : value;
        }

    }
}
