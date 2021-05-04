using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L9Ukol
{
    class Program
    {
        static void Main(string[] args)
        {
            // prevzety priklad, zdroj a reseni uvedeny dole
            // zkuste napred naprogramovat sami ;)


            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            // Najdi slova, ktera zacinaji na 'L'
            IEnumerable<string> LFruits;

            foreach (string fruit in LFruits)
            {
                Console.WriteLine(fruit);
            }


            List<int> mixedNumbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };

            // Najdi cisla delitenla bezezbytku 4 nebo 6
            List<int> fourSixMultiples;
            foreach (int number in fourSixMultiples)
            {
                Console.WriteLine(number);
            }


            List<string> names = new List<string>()
        {
            "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
            "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
            "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
            "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
            "Francisco", "Tre"
        };

            // Setrid jmena v poli
            List<string> ascending;
            List<string> descending;
            foreach (string item in ascending)
            {
                Console.WriteLine(item);
            }

            List<int> numbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };
            // Vypis pocet cisel v seznamu
            Console.WriteLine(/*???*/);

            List<double> purchases = new List<double>()
        {
            2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
        };
            // Vypis soucet vsech cisel v seznamu
            Console.WriteLine(/*???*/);

            List<double> prices = new List<double>()
        {
            879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
        };
            // Vypis nejvyssi cenu v seznamu
            Console.WriteLine(/*???*/);


            List<int> wheresSquaredo = new List<int>()
        {
            66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
        };

            // toto zadani upraveno:
            // Vypis cisla mensi nez 60
            List<int> listA;
            // Vypisuj cisla tak dlouho, dokud budou mensi nez 80
            List<int> listB;
            foreach (var item in listA)
            {
                Console.WriteLine(item.ToString());
            }


            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

            // Opet zjednoduseno:
            // Ze seznamu zakazniku vyber milionare (podle zustatku na uctu -- balance)
            // a zgrupuj je podle banky
            var groupedByBank;

            foreach (var item in groupedByBank)
            {
                Console.WriteLine($"{item.Key}: {string.Join(", ", item)}");
            }


            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };


            // Z puvodniho seznamu zakazniku vyber milionare a vytvor z nich seznam novych zakazniku,
            // kteri budou mit stejne jmeno a stav uctu (balance), ale banka bude obsahovat plne jmeno
            // podle seznamu bank
            List<Customer> millionaireReport;

            foreach (Customer customer in millionaireReport)
            {
                Console.WriteLine($"{customer.Name} at {customer.Bank}");
            }


            // Zdroj (a reseni)
            // https://gist.github.com/stevebrownlee/44f3c78a4de63c258d8a72eea1285834#file-linq-exercises-cs
        }
    }
}
