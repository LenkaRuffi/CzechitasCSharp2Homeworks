using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZjednodusenyUcetniDenik
{
    class Income : Item
    {
        public double IncomeAmount { get; private set; }

        public Income(string invoiceNumber, string invoiceDescription, string counterPartyName, Address counterPartyAddress, string counterpartyIdentificateNumber, string counterpartyTaxIdentityNumber, DateTime? invoiceDate, DateTime? dueDate, DateTime? paymentDate, string itemCategory, ItemType itemType, double incomeAmount) : base(invoiceNumber, invoiceDescription, counterPartyName, counterPartyAddress, counterpartyIdentificateNumber, counterpartyTaxIdentityNumber, invoiceDate, dueDate, paymentDate, itemCategory, itemType)
        {
            IncomeAmount = incomeAmount;   
        }
    }
}
