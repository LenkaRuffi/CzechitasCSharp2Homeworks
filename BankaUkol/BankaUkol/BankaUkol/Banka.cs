using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaUkol
{
    class Banka
    {
        Dictionary<string, Ucet> SeznamUctu = new Dictionary<string, Ucet>();   
        
        public void ZalozUcet(string jmenoVlastnika, double pocatecniZustatek)
        {
            Ucet novyUcet = new Ucet(jmenoVlastnika, pocatecniZustatek);
            SeznamUctu.Add(jmenoVlastnika, novyUcet);
        }

        public IUcet NajdiUcet(string jmenoVlastnika)
        {
            Ucet ucet;

            if (SeznamUctu.TryGetValue(jmenoVlastnika, out ucet))
            {
                Console.WriteLine("Jedná se o tento účet:  {0}.", ucet);
            }
            else
            {
                Console.WriteLine("Účet se zadaným vlastníkem nenalezen.");
            }

            return ucet as IUcet;
        }

        public void UlozPenize(string jmenoVlastnika, double ukladanaCastka)
        {
            Ucet navysovanyUcet;

            SeznamUctu.TryGetValue(jmenoVlastnika, out navysovanyUcet);

            navysovanyUcet.Zustatek = navysovanyUcet.Zustatek + ukladanaCastka;
                        
        }

        public void VypisSeznamUctu()
        {
            foreach(var ucet in SeznamUctu)
            {
                Console.WriteLine(ucet.Value);
            }
        }
    }
}
