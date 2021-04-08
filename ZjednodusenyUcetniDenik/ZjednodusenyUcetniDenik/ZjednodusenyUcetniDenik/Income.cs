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

        public Income(string invoiceNumber, string invoiceDescription, double incomeAmount, ItemType itemType) : base(invoiceNumber, invoiceDescription, itemType)
        {
            IncomeAmount = incomeAmount;   
        }
    }
}
