using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UkolPraceSeSoubory
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Do proměnné typu string uložte cestu na plochu aktuálního uživatele
Zkontrolujte, že na ploše existuje složka Czechitas, a pokud ne, vytvořte ji
Vytvořte nebo použijte třídu Navsteva (z lekce) a vytvořte list s alespoň 2 návštěvami
Do složky Czechitas uložte soubor navstevy.csv, ve kterém bude na každém řádku uložena informace o jedné návštěvě z listu, oddělená čárkou např:
Jarda,10,
Vitek,11,
Potom z CSV souboru načtěte návštěvy a zobrazte na konzoli
Pokud soubor csv již existuje, při spuštění programu jej přepište.
Nepoužívejte pomocné knihovny pro práci s CSV (CsvHelper apod), csv je jednoduchý formát, který načte třeba Excel :) */

            string cestaNaPlochuAktUzivalele = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string directoryName = "Czechitas";
            string fileName = "navstevy.csv";
            string celaCestaKCzechitas = Path.Combine(cestaNaPlochuAktUzivalele, directoryName, fileName);
            List<Navsteva> listNavstev = new List<Navsteva>();       
            List<Navsteva> nactenyListNavstev = new List<Navsteva>();       

            listNavstev.Add(new Navsteva(10, "Jarda"));
            listNavstev.Add(new Navsteva(11, "Vitek"));

            if (!Directory.Exists(Path.GetDirectoryName(celaCestaKCzechitas)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(celaCestaKCzechitas));
            }

            using (StreamWriter sw = new StreamWriter(celaCestaKCzechitas, false))
            {
               foreach(Navsteva navsteva in listNavstev)
                {
                    sw.WriteLine(navsteva);
                }
                
            }

            using (StreamReader sr = new StreamReader(celaCestaKCzechitas))
            {
               while(!sr.EndOfStream)
                {
                    string radek = sr.ReadLine();
                    string[] castiNavstevy = radek.Split(',');
                    string jmeno = castiNavstevy[0];
                    int vek = int.Parse(castiNavstevy[1]);

                    nactenyListNavstev.Add(new Navsteva(vek, jmeno));

                    //Console.WriteLine(radek);
                }
               
            }

            foreach(Navsteva nactenaNavsteva in nactenyListNavstev)
            {
                Console.WriteLine(nactenaNavsteva);
            }

           

            Console.ReadLine();


        }
    }
}