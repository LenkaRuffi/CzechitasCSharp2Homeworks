using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkolL4
{
    class Bojovnik
    {
        /*prop TAB TAB - vytvoří vám šablonu pro auto property
          propfull TAB TAB - vytvoří kompletní property i s fieldem
          propg TAB TAB - vytvoří auto property s public get a private set*/

        public string Jmeno { get; private set; }
        public int Sila { get; private set; }

        public int Brneni { get; private set; }

        public int Zivot { get; private set; } //popremyslet nad ify a min max, aby si to mohla hlidat primo property

        public bool JeZivy { get; private set; }

        public Zbrane Zbran { get; private set; }

        public Bojovnik(string jmeno, int sila, int zivot, int brneni, Zbrane zbran)
        {
            Jmeno = jmeno;
            Sila = sila >= 10 ? Sila = sila : sila = 10;
            Zivot = zivot >= 0 && zivot <= 100 ? Zivot = zivot : Zivot = 100;
            Brneni = brneni >= 0 && brneni <= 50 ? Brneni = brneni : Brneni = 50;
            Zbran = zbran;

        }

        public void UtocNa(Bojovnik protivnik)
        {
            protivnik.Zivot -= Sila;

            switch (Zbran)
            {
                case Zbrane.Mec:
                    protivnik.Zivot = protivnik.Brneni == 0 ? protivnik.Zivot -= Sila : protivnik.Zivot -= (Sila - protivnik.Brneni);
                    protivnik.Brneni = protivnik.Brneni > 0 ? protivnik.Brneni -= (Sila / 10) : protivnik.Brneni;
                    break;
                case Zbrane.Palcat:
                    protivnik.Zivot -= Sila / 4;
                    protivnik.Brneni = protivnik.Brneni > 0 ? protivnik.Brneni -= (Sila / 4) : protivnik.Brneni;
                    break;
                case Zbrane.Kopi:
                    protivnik.Zivot = protivnik.Brneni == 0 ? protivnik.Zivot -= (Sila / 2) : protivnik.Zivot -= (Sila - protivnik.Brneni);
                    protivnik.Brneni = protivnik.Brneni > 0 ? protivnik.Brneni -= (Sila / 10) : protivnik.Brneni;
                    break;
                case Zbrane.Sekacek:
                    protivnik.Zivot -= Sila / 5;
                    protivnik.Brneni = protivnik.Brneni > 0 ? protivnik.Brneni -= (Sila / 5) : protivnik.Brneni;
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return $"{ Jmeno} Život: {Zivot} Brnění: {Brneni}";
        }

    }
}
