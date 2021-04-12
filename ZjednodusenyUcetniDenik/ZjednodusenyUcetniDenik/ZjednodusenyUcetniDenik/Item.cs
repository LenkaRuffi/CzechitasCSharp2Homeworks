using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZjednodusenyUcetniDenik
{
   public class Item
    {
        public string InvoiceNumber { get; private set; }
        public string InvoiceDescription { get; private set; }
        public string CounterpartyName { get; private set; }

        public Address CounterPartyAddress { get;  set; }

        public string CounterpartyIdentificateNumber { get; private set; } //IČ
        public string CounterpartyTaxIdentityNumber { get; private set; } //DIČ
        public DateTime? InvoiceDate { get; private set; } //DUZP
        public DateTime? DueDate { get; private set; } //Datum splatnosti
        public DateTime? PaymentDate { get; private set; } //Datum úhrady
        public string ItemCategory { get; private set; }
        public ItemType ItemType { get; set; }
        public double Amount { get; private set; }

        public Item(string invoiceNumber, string invoiceDescription, string counterPartyName, Address counterPartyAddress, string counterpartyIdentificateNumber, string counterpartyTaxIdentityNumber, DateTime? invoiceDate, DateTime? dueDate, DateTime? paymentDate, string itemCategory, ItemType itemType, double amount)
        {
            InvoiceNumber = invoiceNumber;
            InvoiceDescription = invoiceDescription;
            CounterpartyName = counterPartyName;
            CounterPartyAddress = counterPartyAddress;
            CounterpartyIdentificateNumber = counterpartyIdentificateNumber;
            CounterpartyTaxIdentityNumber = counterpartyTaxIdentityNumber;
            InvoiceDate = invoiceDate;
            DueDate = dueDate;
            PaymentDate = paymentDate;
            ItemCategory = itemCategory;
            ItemType = itemType;
            Amount = amount;
        }

        public override string ToString()
        {
            return InvoiceNumber + " " + InvoiceDescription;
        }
    }
}
