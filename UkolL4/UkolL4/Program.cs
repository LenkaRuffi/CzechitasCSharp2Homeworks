﻿using System;
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

            arena.RegistrujBojovnika();

            Console.ReadKey();
        }
    }
}
