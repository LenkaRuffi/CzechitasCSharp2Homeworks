using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaUkol
{
    class Ucet : IUcet
    {
        public double Zustatek { get; set; }

        public string Vlastnik { get; private set; }

        public Ucet(string vlastnik, double pocatecniZustatek)
        {
            Vlastnik = vlastnik;
            Zustatek = pocatecniZustatek;
        }

        public void navys()
        { }

        public override string ToString()
        {
            return ($"Vlastnikem uctu je {Vlastnik} a zůstatek je {Zustatek}");
        }
    }
}
