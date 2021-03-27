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

        public int Zivot { get; private set; } 

        public Zbran Zbran { get; private set; }

        public Bojovnik(string jmeno, int sila, int zivot, int brneni, Zbran zbran)
        {
            Jmeno = jmeno;
            Sila = sila >= 10 ? Sila = sila : sila = 10;
            Zivot = zivot >= 0 && zivot <= 100 ? Zivot = zivot : Zivot = 100;
            Brneni = brneni >= 0 && brneni <= 50 ? Brneni = brneni : Brneni = 50;
            Zbran = zbran;

        }

        public void UtocNa(Bojovnik protivnik)
        {
            switch (Zbran)
            {
                case Zbran.Mec:
                    protivnik.Brneni -= (protivnik.Brneni - (Sila / 10)) >= 0 ? (Sila / 10) : protivnik.Brneni;
                    protivnik.Zivot -= protivnik.Brneni == 0 ? Sila : (Sila - protivnik.Brneni);          
                    break;
                case Zbran.Palcat:
                    protivnik.Brneni -= (protivnik.Brneni - (Sila / 4)) >= 0 ? (Sila / 4) : protivnik.Brneni;
                    protivnik.Zivot -= (Sila / 4);                   
                    break;
                case Zbran.Kopi:
                    protivnik.Brneni -= (protivnik.Brneni - (Sila / 10)) >= 0 ? (Sila / 10) : protivnik.Brneni;
                    protivnik.Zivot -= protivnik.Brneni == 0 ? (Sila/2) : (Sila/2 - protivnik.Brneni);                                   
                    break;
                case Zbran.Sekacek:                            
                    protivnik.Brneni -= (protivnik.Brneni - (Sila / 5)) >= 0 ? (Sila / 5) : protivnik.Brneni;
                    protivnik.Zivot -= (Sila / 5);
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return $"{ Jmeno} Život: {Zivot} Brnění: {Brneni} Síla: {Sila} Zbraň: {Zbran}";
        }

        public bool OverZdaJeBojovnikZivy()
        {
            return Zivot > 0;
        }

    }
}
