using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZjednodusenyUcetniDenik
{
    public class Filter
    {
        public Item actualFilteredDataItem { get; set; }

        public bool ItemTypeCheckBox { get; set; }
        public bool AmountCheckBox { get; set; }
        public bool InvoiceNumberCheckBox { get; set; }
        public bool InvoiceDescriptionCheckBox { get; set; }
        public bool ItemCategoryCheckBox { get; set; }
        public bool InvoiceDateCheckBox { get; set; }
        public bool DueDateCheckBox { get; set; }
        public bool PaymentDateCheckBox { get; set; }
        public bool YearCheckBox { get; set; }
        public bool CounterpartyNameCheckBox { get; set; }
        public bool CounterpartyIdentificateNumberCheckBox { get; set; }
        public bool CounterpartyTaxIdentityNumberCheckBox { get; set; }
        public bool CounterpartyStreetCheckBox { get; set; }
        public bool CounterpartyZipCodeCheckBox { get; set; }
        public bool CounterpartyAddressTownCheckBox { get; set; }
        public bool CounterpartyAddressStateCheckBox { get; set; }
          
    }
}
