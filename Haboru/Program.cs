using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Haboru
{
    class Program
    {
        static void Main(string[] args)
        {
            Feladatok f = new Feladatok();
            f.fajlBeolvasas();
            f.virusKitores();
            f.haboruElsoEv();
            Console.WriteLine("\n");
            //f.bekeres();
            //Console.WriteLine();
            //f.jelentes(f.Bevitel);
            Console.WriteLine();
            f.haboruMasidikEv();

            Console.ReadLine();
        }
    }
}
