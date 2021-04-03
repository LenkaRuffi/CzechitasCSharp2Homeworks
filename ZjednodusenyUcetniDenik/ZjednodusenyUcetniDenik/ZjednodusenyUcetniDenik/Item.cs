using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZjednodusenyUcetniDenik
{
    class Item
    {
        public string InvoiceNumber { get; private set; }
        public string InvoiceDescription { get; private set; }
        public string CounterpartyName { get; private set; }
        public string CounterpartyAddressStreet { get; private set; }
        public string CounterpartyAddressZipCode { get; private set; }
        public string CounterpartyAddressTown { get; private set; }
        public string CounterpartyAddressState { get; private set; }
        public string CounterpartyIdentificateNumber { get; private set; } //IČ
        public string CounterpartyTaxIdentityNumber { get; private set; } //DIČ
        public DateTime InvoiceDate { get; private set; } //DUZP
        public DateTime DueDate { get; private set; } //Datum splatnosti
        public DateTime PaymentDate { get; private set; } //Datum úhrady
        public string ItemCategory { get; private set; }

    }
}
