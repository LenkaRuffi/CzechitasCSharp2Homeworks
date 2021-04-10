using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZjednodusenyUcetniDenik
{
    public class Address
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Town { get; set; }
        public string State { get; set; }

        public Address(string street, string zipCode, string town, string state)
        {
            Street = street;
            ZipCode = zipCode;
            Town = town;
            State = state;
        }
    }
}
