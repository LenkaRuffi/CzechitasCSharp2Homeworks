using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZjednodusenyUcetniDenik
{
    public class Filter : Item
    {
        public bool? ItemTypeCheckBox { get; set; } = false;
        public bool? AmountCheckBox { get; set; } = false;
        public bool? InvoiceNumberCheckBox { get; set; } = false;
        public bool? InvoiceDescriptionCheckBox { get; set; } = false;
        public bool? ItemCategoryCheckBox { get; set; } = false;
        public bool? InvoiceDateCheckBox { get; set; } = false;
        public bool? DueDateCheckBox { get; set; } = false;
        public bool? PaymentDateCheckBox { get; set; } = false;
        public bool? YearCheckBox { get; set; } = false;
        public bool? CounterpartyNameCheckBox { get; set; } = false;
        public bool? CounterpartyIdentificateNumberCheckBox { get; set; } = false;
        public bool? CounterpartyTaxIdentityNumberCheckBox { get; set; } = false;
        public bool? CounterpartyStreetCheckBox { get; set; } = false;
        public bool? CounterpartyZipCodeCheckBox { get; set; } = false;
        public bool? CounterpartyAddressTownCheckBox { get; set; } = false;
        public bool? CounterpartyAddressStateCheckBox { get; set; } = false;

        public double? AmountTo { get; private set; }
        public DateTime? InvoiceDateTo { get; private set; } //DUZP
        public DateTime? DueDateTo { get; private set; } //Datum splatnosti
        public DateTime? PaymentDateTo { get; private set; } //Datum úhrady
        public int? AccountingYearTo { get; private set; }

        public Filter(bool? itemTypeCheckBox, bool? amountCheckBox, bool? invoiceNumberCheckBox, bool? invoiceDescriptionCheckBox, bool? itemCategoryCheckBox,
            bool? invoiceDateCheckBox, bool? dueDateCheckBox, bool? paymentDateCheckBox, bool? yearCheckBox, bool? counterpartyNameCheckBox,
            bool? counterpartyIdentificateNumberCheckBox, bool? counterpartyTaxIdentityNumberCheckBox, bool? counterpartyStreetCheckBox, bool? counterpartyZipCodeCheckBox,
            bool? counterpartyAddressTownCheckBox, bool? counterpartyAddressStateCheckBox, string invoiceNumber, string invoiceDescription, string counterPartyName, 
            Address counterPartyAddress, string counterpartyIdentificateNumber, string counterpartyTaxIdentityNumber, DateTime? invoiceDate, DateTime? dueDate, 
            DateTime? paymentDate, string itemCategory, ItemType itemType, double? amount, int? accountingYear, double? amountTo, DateTime? invoiceDateTo,
            DateTime? dueDateTo, DateTime? paymentDateTo, int? accountingYearTo ) : base(invoiceNumber, invoiceDescription, counterPartyName, 
            counterPartyAddress, counterpartyIdentificateNumber, counterpartyTaxIdentityNumber, invoiceDate, dueDate,  paymentDate, itemCategory, 
            itemType, amount, accountingYear)
        {
            ItemTypeCheckBox = itemTypeCheckBox;
            AmountCheckBox = amountCheckBox;
            InvoiceNumberCheckBox = invoiceNumberCheckBox;
            InvoiceDescriptionCheckBox = invoiceDescriptionCheckBox;
            ItemCategoryCheckBox = itemCategoryCheckBox;
            InvoiceDateCheckBox = invoiceDateCheckBox;
            DueDateCheckBox = dueDateCheckBox;
            PaymentDateCheckBox = paymentDateCheckBox;
            YearCheckBox = yearCheckBox;
            CounterpartyNameCheckBox = counterpartyNameCheckBox;
            CounterpartyIdentificateNumberCheckBox = counterpartyIdentificateNumberCheckBox;
            CounterpartyTaxIdentityNumberCheckBox = counterpartyTaxIdentityNumberCheckBox;
            CounterpartyStreetCheckBox = counterpartyStreetCheckBox;
            CounterpartyZipCodeCheckBox = counterpartyZipCodeCheckBox;
            CounterpartyAddressTownCheckBox = counterpartyAddressTownCheckBox;
            CounterpartyAddressStateCheckBox = counterpartyAddressStateCheckBox;
            AmountTo = amountTo;
            InvoiceDateTo = invoiceDateTo;
            DueDateTo = dueDateTo;
            PaymentDateTo = paymentDateTo;
            AccountingYearTo = accountingYearTo;
        }          
    }
}
