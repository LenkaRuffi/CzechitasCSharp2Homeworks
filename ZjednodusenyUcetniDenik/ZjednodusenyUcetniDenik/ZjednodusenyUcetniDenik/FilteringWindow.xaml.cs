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
            selectedItems = accountingBook.AccountingBookItems; //toto nečekaně bude mit na konci zase vsechny polozky pokud ani jeden filtr nebude true
                                                                                  //ještě přemýšlím, jestli není lepší použít FilteredObservableCollection a filter nastavit v ní

            //vytvorit pomocnej seznam, do kteryho na zacatku nahraji data, ten pak necham projet pres ify a budu muset vymyslet, jak udelat podminku, ze pomocny seznam preklopim do selected item
            /*if (CounterpartyNameCheckBox.IsChecked == true)
            {
                selectedItems =
                from Item in accountingBook.AccountingBookItems
                where Item.CounterpartyName == CounterpartyNameTextBox.Text
                select Item;
            }*/

            //toto se pry pise takto kvuli prehlednosti

            
            if (ItemTypeCheckBox.IsChecked == true) 
            { 
               int selectedValue = int.Parse((string)ItemTypeComboBox.SelectedValue);

                selectedItems = selectedItems.Where(i => (int)i.ItemType == selectedValue).Select(i => i); 
            }
            if (AmountCheckBox.IsChecked == true) { selectedItems = selectedItems.Where(i => i.Amount >= IfNullReturnMaxDouble(AmountDoubleUpDownFrom.Value) && i.Amount <= IfNullReturnMaxDouble(AmountDoubleUpDownTo.Value)).Select(i => i); }
            if (InvoiceNumberCheckBox.IsChecked == true) { selectedItems = selectedItems.Where(i => i.InvoiceNumber == InvoiceNumberTextBox.Text).Select(i => i); }
            if (InvoiceDescriptionCheckBox.IsChecked == true) { selectedItems = selectedItems.Where(i => i.InvoiceNumber == InvoiceDescriptionTextBox.Text).Select(i => i); }
            if (ItemCategoryCheckBox.IsChecked == true) { selectedItems = selectedItems.Where(i => i.InvoiceNumber == ItemCategoryTextBox.Text).Select(i => i); }
            // opravit date - if (InvoiceDateCheckBox.IsChecked == true) { selectedItems = selectedItems.Where(i => i.InvoiceNumber == ItemCategoryTextBox.Text).Select(i => i); }


            if (YearCheckBox.IsChecked == true) { selectedItems = selectedItems.Where(i => i.AccountingYear >= IfNullReturnMaxDouble(YearIntUpDownFrom.Value) && i.AccountingYear <= IfNullReturnMaxDouble(YearIntUpDownTo.Value)).Select(i => i); }
            if (CounterpartyNameCheckBox.IsChecked == true) { selectedItems = selectedItems.Where(i => i.CounterpartyName == CounterpartyNameTextBox.Text).Select(i => i); }
            if (CounterpartyIdentificateNumberCheckBox.IsChecked == true) { selectedItems = selectedItems.Where(i => i.CounterpartyIdentificateNumber == CounterpartyIdentificateNumberTextBox.Text).Select(i => i); }
            if (CounterpartyTaxIdentityNumberCheckBox.IsChecked == true) { selectedItems = selectedItems.Where(i => i.CounterpartyTaxIdentityNumber == CounterpartyIdentificateNumberTextBox.Text).Select(i => i); }
            if (CounterpartyStreetCheckBox.IsChecked == true) { selectedItems = selectedItems.Where(i => i.CounterPartyAddress.Street == CounterPartyStreetTextBox.Text).Select(i => i); }
            
            /*

             DueDateCheckBox.IsChecked = ActualFilter.DueDateCheckBox;
             PaymentDateCheckBox.IsChecked = ActualFilter.PaymentDateCheckBox;
             
            
             CounterpartyStreetCheckBox.IsChecked = ActualFilter.CounterpartyStreetCheckBox;
             CounterpartyZipCodeCheckBox.IsChecked = ActualFilter.CounterpartyZipCodeCheckBox;
             CounterpartyAddressTownCheckBox.IsChecked = ActualFilter.CounterpartyAddressTownCheckBox;
             CounterpartyAddressStateCheckBox.IsChecked = ActualFilter.CounterpartyAddressStateCheckBox;*/






            /* No ty když uděláš linq dotaz, třeba var položky = seznam.where(i => i.JeNeco);
             Poslal(a) Jaroslav, Dnes v 20:03
 Pak máš test, jestli je zapnutý další filtr a je znovu
 Poslal(a) Jaroslav, Dnes v 20:03
 Položky = položky.where(i => I.NecoJineho);
             Poslal(a) Jaroslav, Dnes v 20:03
 A po všech testech je foreach
 Poslal(a) Jaroslav, Dnes v 20:03
 Takže retezis linq a on se vyhodnotí až na závěr
 Poslal(a) Jaroslav, Dnes v 20:03
 To je totiž u linq důležité vědět, on se vyhodnotí až v cyklu nebo když dáš.To list apod
 Poslal(a) Jaroslav, Dnes v 20:03
 On se ne vyhodnotí když ho napises
 Poslal(a) Jaroslav, Dnes v 20:03
 Le až ho procházís
 Poslal(a) Jaroslav, Dnes v 20:03
 Takže můžeš jakoby pořád nastavovat další části linqu
 Poslal(a) Jaroslav, Dnes v 20:03
 Proto ti to pomuze
 Poslal(a) Jaroslav, Dnes v 20:03
 Bude to rychle a přitom elegantní, bude to mít vyfiltrovane vlastně až na konec kompletně z jednoho linqu který postupně vznikl
 Posláno Dnes v 20:05
 Nad tím se musím zamyslet, až vítá domluví
 Posláno Dnes v 20:08
 Měla jsem to nějak jinak namysleny ale asi sloziteji

 Poslal(a) Jaroslav, Dnes v 20:11
 proste to bude
 if (prvniFiltr) polozky = polozky.Where(p => p.Cislo == hodnotaPrvnihoFiltru);
             if (druhyFiltr) polozky = polozky.Where(p => p.Adresa == hodnotaAdresy);
             ....vyfiltrovanePolozky = polozky.ToList();
             Poslal(a) Jaroslav, Dnes v 20:11
 mozna to nemam uplne dobre pojmenovany, misto polozky by melo byt filtrovaniPolozek treba, jako ze je to aplikace toho linqu*/

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
                DueDateDatePickerFrom.SelectedDate, PaymentDateDatePickerFrom.SelectedDate, ItemCategoryTextBox.Text, (ItemType)item, AmountDoubleUpDownFrom.Value, YearIntUpDownFrom.Value, AmountDoubleUpDownTo.Value,
                InvoiceDateDatePickerTo.SelectedDate, DueDateDatePickerTo.SelectedDate, PaymentDateDatePickerTo.SelectedDate, YearIntUpDownTo.Value);           
           
        }

        private void setActualFilterToWindow()
        {           
            setCheckboxToActualFilterWindow();
            setItemToActualFilterWindow();
        }

        private void setCheckboxToActualFilterWindow()
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
        

            private void setItemToActualFilterWindow()
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


    }
}
