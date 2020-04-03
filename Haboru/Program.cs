using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haboru
{
    class Program
    {
        static void Main(string[] args)
        {
            Feladatok f = new Feladatok();
            f.FajlBeolvasas();
            f.VirusKitores();
            f.HaboruElsoEv();
            Console.ReadLine();

        }
    }
}
