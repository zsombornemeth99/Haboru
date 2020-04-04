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
            
        }

        public void fertozottsegSzamitas(Pokemon p)
        {
            Random r = new Random();
            
            if (generacio() == 1)
            {
                int s = p.getOsszStat() - r.Next(100, 150);
                p.setOsszStat(s);
            }
            else if (generacio() == 2)
            {
                int s = p.getOsszStat() + r.Next(100, 150);
                p.setOsszStat(s);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", getNev(), getAzonosito(), getTermElem(), getOsszStat());
        }
    }
}
