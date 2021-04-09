using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaUkol
{
    class Program
    {
        /*Vytvořte interface IUcet, který bude mít property Zustatek s get(bez set) a property Vlastnik s get(také bez set)
        Vytvořte třídu Ucet, která bude dědit interface IUcet, implementovat properties Zustatek(get i set) a Vlastník, který bude nastaven jen z konstruktoru.
        Vytvořte konstruktor Uctu, který bude brát jako parametry jméno vlastníka a počáteční zůstatek.
        Vytvořte třídu Banka, která bude mít funkci ZalozUcet s parametry počátečního zůstatku a jména vlastníka.
        Vytvořte bance funkci NajdiUcet, která vrátí IUcet podle jména vlastníka.
        Vytvořte bance funkci UložPeníze, která přidá do účtu vlastníka odpovídající obnos.
        Vytvořte program, který bude mít instanci Banky, vytvoří 3 účty (nemusíte dělat načítání z konzole, klidně v kodu vytvořit)
        Vypište aktuální stav účtů v Bance
        Uložte do jednoho účtu další peníze a opět vypište aktuální stav účtů
        Získejte jeden účet z Banky do proměnné typu IUcet pomocí NajdiUcet.Nesmí mu jít změnit Zustatek, musí jít jedině přes příkaz v bance :) */

        /* Jako pomůcku při rozhodování, kdy použít rozhraní a dědičnost, můžete použít:
        Pokud třída A je B -> dědičnost (Pták je Zvíře)
        Pokud třída A umožňuje B -> interface (ILetani - létat může pták, letadlo, ale i list)
        Pokud chci omezit přístup k třídě -> interface*/

        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }
}
