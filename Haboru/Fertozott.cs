using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haboru
{
    class Fertozott : Pokemon
    {
        private int fertozottsegiSzint;

        public Fertozott(string nev, string azonosito, string termElem, int osszStat) :
            base(nev, azonosito, termElem, osszStat)
        {
            //this.nev = nev;
            //this.azonosito = azonosito;
            //this.termElem = termElem;
            //this.osszStat = osszStat;
        }
        public void fertozottsegSzamitas()
        {
            Random r = new Random();
            int s = r.Next(100, 150);
            if (Generacio() == 1)
            {

            }
        }
    }
}
