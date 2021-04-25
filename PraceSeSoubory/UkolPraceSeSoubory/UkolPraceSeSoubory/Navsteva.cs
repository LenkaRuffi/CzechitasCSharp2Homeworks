using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkolPraceSeSoubory
{
    class Navsteva
    {
        public string Jmeno { get; set; }

        public int Vek { get; set; }

        public Navsteva()
        {

        }

        public Navsteva(int vek, string jmeno)
        {
            Jmeno = jmeno;
            Vek = vek;
        }

    }
}
