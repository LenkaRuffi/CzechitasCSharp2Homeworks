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
        public Dictionary<int, Bojovnik> SlovnikZivychBojovniku;
        public List<Bojovnik> SeznamZivychBojovniku;
        private Random generatorNahodnychCisel;
        List<Bojovnik> vyzyvatele;
        List<Bojovnik> souperi;

        public Arena()
        {
            SeznamBojovniku = new List<Bojovnik>();
            SeznamZivychBojovniku = new List<Bojovnik>();
            SlovnikZivychBojovniku = new Dictionary<int, Bojovnik>();
            vyzyvatele = new List<Bojovnik>();
            souperi = new List<Bojovnik>();
        }

        public void ZobravStavBojovniku(List<Bojovnik> seznamBojovnikuKZobrazeni)
        {
            string oddelovac = new string('=', 60);
            Console.WriteLine("Stav bojovníků: ");
            Console.WriteLine(oddelovac);
            foreach (Bojovnik bojovnik in seznamBojovnikuKZobrazeni)
            {
                Console.WriteLine(bojovnik);
            }
            Console.WriteLine(oddelovac);
        }

        private void BojJednoKolo(Bojovnik bojovnik, Bojovnik souper)
        {
            while (bojovnik.OverZdaJeBojovnikZivy() && souper.OverZdaJeBojovnikZivy())
            {
                if (bojovnik.OverZdaJeBojovnikZivy())
                {
                    bojovnik.UtocNa(souper);
                }

                if (souper.OverZdaJeBojovnikZivy())
                {
                    souper.UtocNa(bojovnik);
                }
            }

            if (bojovnik.OverZdaJeBojovnikZivy())
            {
                SmazMrtvehoBojovnikaZeSeznamuZivych(souper);
            }
            else if (souper.OverZdaJeBojovnikZivy())
            {
                SmazMrtvehoBojovnikaZeSeznamuZivych(bojovnik);
            }
        }

        public void RegistrujBojovnika()
        {
            string jmeno;
            int sila;
            int zivot;
            int brneni;
            Zbran zbran;

            Console.WriteLine("Zadej jméno bojovníka: ");
            jmeno = Console.ReadLine();

            sila = VratZadaneCislo("Zadej sílu bojovníka: ");
            while (!ZkontrolujZdaCisloJeVZadanemRozmezi(sila, 10))
            {
                sila = VratZadaneCislo("Zadej znovu sílu bojovníka (minimální síla je 10): ");
            }

            zivot = VratZadaneCislo("Zadej život bojovníka: ");
            while (!ZkontrolujZdaCisloJeVZadanemRozmezi(zivot, 0, 100))
            {
                zivot = VratZadaneCislo("Zadej znovu život bojovníka (v rozmezí 0 - 100): ");
            }

            brneni = VratZadaneCislo("Zadej brnění bojovníka: ");
            while (!ZkontrolujZdaCisloJeVZadanemRozmezi(brneni, 0, 50))
            {
                brneni = VratZadaneCislo("Zadej znovu brnění bojovníka (v rozmezí 0 - 50): ");
            }

            VypisVsechZbrani();
            zbran = (Zbran)VratZadaneCislo("Zadej číslo zbraně bojovníka: ");
            while (!ZkontrolujZdaCisloJeVZadanemRozmezi((int)zbran, 1, Enum.GetValues(typeof(Zbran)).Length))
            {
                zbran = (Zbran)VratZadaneCislo("Zadej znovu zbraň bojovníka: ");
            }

            SeznamBojovniku.Add(new Bojovnik(jmeno, sila, zivot, brneni, zbran));
        }

        public int VratZadaneCislo(string textKZobrazeni, int min = 0, int max = 100)
        {
            Console.WriteLine(textKZobrazeni);
            string cisloText = Console.ReadLine();
            bool jeCislo = int.TryParse(cisloText, out int vraceneCislo);
            while (!jeCislo)
            {
                Console.WriteLine("Nebylo zadáno číslo, zadej znovu: ");
                cisloText = Console.ReadLine();
                jeCislo = int.TryParse(cisloText, out vraceneCislo);
            }
            return vraceneCislo;
        }

        private void VypisVsechZbrani()
        {
            int cisloZbrane = 1;

            foreach (Zbran zbranProVypis in Enum.GetValues(typeof(Zbran))) //get values vraci pole ve kterem jsou vsechny polozky toho typu, get names vraci pole stringu, kde jsou nazvy jako stringy
            {
                Console.WriteLine($"Je na výběr z těchto zbraní: { zbranProVypis} číslo: {cisloZbrane}");
                cisloZbrane++;
            }

        }

        public bool ZkontrolujZdaCisloJeVZadanemRozmezi(int cislo, int min = Int32.MinValue, int max = Int32.MaxValue)
        {
            return cislo >= min && cislo <= max;
        }

        private void SmazMrtvehoBojovnikaZeSeznamuZivych(Bojovnik mrtvy)
        {
            SeznamZivychBojovniku.Remove(mrtvy);
        }

        private void NactiVychoziStavZivychBojovniku()
        {
            int poradi = 1;
            foreach (Bojovnik bojovnik in SeznamBojovniku)
            {
                SeznamZivychBojovniku.Add(bojovnik);
                SlovnikZivychBojovniku.Add(poradi, bojovnik);
                poradi++;
            }
        }

        private void NactiStavZivychBojovnikuDoSlovniku()
        {
            int poradi = 1;
            SlovnikZivychBojovniku.Clear();
            foreach (Bojovnik bojovnik in SeznamZivychBojovniku)
            {
                SlovnikZivychBojovniku.Add(poradi, bojovnik);
                poradi++;
            }
        }

        private bool OverKonecBoje(List<Bojovnik> nactenySeznamBojovniku)
        {
            return nactenySeznamBojovniku.Count <= 1;
        }

        public void CelkovyBoj()
        {
            generatorNahodnychCisel = new Random();
            
            while (!OverKonecBoje(SeznamZivychBojovniku))
            {
                NactiStavZivychBojovnikuDoSlovniku();               

                RozdeleniNaVyzyvateleASoupere();

                for (int i = 0; i < souperi.Count; i++)
                {
                    BojJednoKolo(vyzyvatele[i], souperi[i]);
                }
                ZobravStavBojovniku(SeznamZivychBojovniku);
            }
        }

        private void RozdeleniNaVyzyvateleASoupere()
        {
            int celkovyPocetBojovniku = SlovnikZivychBojovniku.Count() + 1;

            while (!OverKonecBoje(SlovnikZivychBojovniku.Values.ToList<Bojovnik>()))
            {
                int keyBojovnika = generatorNahodnychCisel.Next(celkovyPocetBojovniku);
                Bojovnik vyzyvatel;
                Bojovnik souper;

                while (!SlovnikZivychBojovniku.TryGetValue(keyBojovnika, out vyzyvatel))
                {
                    keyBojovnika = generatorNahodnychCisel.Next(celkovyPocetBojovniku);
                    bool jeToOk = SlovnikZivychBojovniku.TryGetValue(keyBojovnika, out vyzyvatel);
                }

                vyzyvatele.Add(vyzyvatel);
                SlovnikZivychBojovniku.Remove(keyBojovnika);
                generatorNahodnychCisel = new Random(12532);
                keyBojovnika = generatorNahodnychCisel.Next(celkovyPocetBojovniku);

                if (SlovnikZivychBojovniku.Count != 0)
                {
                    while (!SlovnikZivychBojovniku.TryGetValue(keyBojovnika, out souper))
                    {
                        keyBojovnika = generatorNahodnychCisel.Next(celkovyPocetBojovniku);
                        bool jeToOk = SlovnikZivychBojovniku.TryGetValue(keyBojovnika, out souper);
                    }
                    souperi.Add(souper);
                    SlovnikZivychBojovniku.Remove(keyBojovnika);
                }
            }

        }
    }
}
