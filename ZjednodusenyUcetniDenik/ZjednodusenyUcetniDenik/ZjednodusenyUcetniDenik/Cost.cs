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
       
        public Cost(string invoiceNumber, string invoiceDescription) :base(invoiceNumber, invoiceDescription)
        {

        }
    }
}
