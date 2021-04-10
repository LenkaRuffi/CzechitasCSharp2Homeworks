using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZjednodusenyUcetniDenik
{
    public class Cost : Item
    {
        public double CostAmount { get; private set; }
       
        public Cost(string invoiceNumber, string invoiceDescription, string counterPartyName, Address counterPartyAddress, string counterpartyIdentificateNumber, string counterpartyTaxIdentityNumber, DateTime? invoiceDate, DateTime? dueDate, DateTime? paymentDate, string itemCategory, ItemType itemType, double costAmount) : base(invoiceNumber, invoiceDescription, counterPartyName, counterPartyAddress, counterpartyIdentificateNumber, counterpartyTaxIdentityNumber,  invoiceDate, dueDate, paymentDate, itemCategory, itemType)
        {
            CostAmount = costAmount;
        }
    }
}
