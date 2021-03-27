using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkolL4
{
    class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            bool konecZadaní = false;

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(@" 
  ___  ______ _____ _   _   ___  
 / _ \ | ___ \  ___| \ | | / _ \ 
/ /_\ \| |_/ / |__ |  \| |/ /_\ \
|  _  ||    /|  __|| . ` ||  _  |
| | | || |\ \| |___| |\  || | | |
\_| |_/\_| \_\____/\_| \_/\_| |_/
                                 ");

            Console.ResetColor();

            Console.WriteLine("Vítáme tě v naší aréně, nyní můžeš zadat bojovníky: ");

            while(!konecZadaní)
            {
                arena.RegistrujBojovnika();
                int konecZadani = arena.VratZadaneCislo("Pro konec zadaní vlož 1, pro pokračování jakékoliv jiné číslo: ");                
                konecZadaní = arena.ZkontrolujZdaCisloJeVZadanemRozmezi(konecZadani, 1, 1);
            }

            Console.WriteLine("Zadávání bojovníků ukončeno, nyní začne BOJ! (stiskni libovolnou klávesu)");
            arena.NactiVychoziStavZivychBojovniku();
            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@" 
______  _____   ___ 
| ___ \|  _  | |_  |
| |_/ /| | | |   | |
| ___ \| | | |   | |
| |_/ /\ \_/ /\__/ /
\____/  \___/\____/ 
                    ");

            Console.ResetColor();

            arena.ZobravStavBojovniku(arena.SeznamBojovniku);

            arena.CelkovyBoj();

            Console.ReadKey();
        }
    }
}
