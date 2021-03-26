using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkolL4
{
    class Arena
    {
        public List<Bojovnik> SeznamBojovniku;
        private Zbrane vsechnyZbrane = Zbrane.Kopi | Zbrane.Mec | Zbrane.Palcat | Zbrane.Sekacek;

        public Arena()
        {
            SeznamBojovniku = new List<Bojovnik>();
        }

        public void ZobravStavBojovniku()
        {
            string textAreny = "Stav bojovníků: ";
            Console.WriteLine(textAreny.PadLeft(10, '=').PadRight(10, '='));
            foreach(Bojovnik bojovnik in SeznamBojovniku)
            {
                Console.WriteLine(bojovnik);
            }
        }

        public void Boj(Bojovnik bojovnik, Bojovnik souper)
        {
            ZobravStavBojovniku();
            bojovnik.UtocNa(souper);
            souper.UtocNa(bojovnik);
            ZobravStavBojovniku();
        }

        public void RegistrujBojovnika()
        {
            string jmeno;
            int sila;
            int zivot;
            int brneni;
            Zbrane zbran = Zbrane.Kopi;

            Console.WriteLine("Zadej jméno bojovníka: ");
            jmeno = Console.ReadLine();

            sila = VratZadaneCislo("Zadej sílu bojovníka: ");
            zivot = VratZadaneCislo("Zadej život bojovníka: ");
            brneni = VratZadaneCislo("Zadej brnění bojovníka: ");

           
            int cisloZbrane = 1;

            foreach(Zbrane zbranVypis in Enum.GetValues(typeof(Zbrane))) //get values vraci pole ve kterem jsou vsechny polozky toho typu, get names vraci pole stringu, kde jsou nazvy jako stringy
            {
                Console.WriteLine($"Je na výběr z těchto zbraní: { zbran} číslo: {cisloZbrane}");
                cisloZbrane++;
            }

            int zbranCislo = VratZadaneCislo("Zadej číslo zbraně bojovníka: ");


            Bojovnik novyBojovnik = new Bojovnik(jmeno, sila, zivot, brneni, zbran);
            SeznamBojovniku.Add(novyBojovnik);
        }

        public int VratZadaneCislo(string textKZobrazeni, int min = 0, int max = 100)
        {
            Console.WriteLine(textKZobrazeni);
            string cisloText = Console.ReadLine();
            bool jeCislo = int.TryParse(cisloText, out int vraceneCislo);
            while(!jeCislo)
            {
                Console.WriteLine("Nebylo zadáno číslo, zadej znovu: ");
                cisloText = Console.ReadLine();
                jeCislo = int.TryParse(cisloText, out vraceneCislo);
            }
            return vraceneCislo;

        }
    }
}
