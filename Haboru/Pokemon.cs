using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haboru
{
    class Pokemon
    {
        private string nev;
        private string azonosito;
        private string termElem;
        private int osszStat;

        public Pokemon(string nev, string azonosito, string termElem, int osszStat)
        {
            this.nev = nev;
            this.azonosito = azonosito;
            this.termElem = termElem;
            this.osszStat = osszStat;
        }

        public string getNev()
        {
            return this.nev;
        }
        public string getAzonosito()
        {
            return this.azonosito;
        }
        public string getTermElem()
        {
            return this.termElem;
        }
        public int getOsszStat()
        {
            return this.osszStat;
        }

        public void setNev(string nev)
        {
            this.nev = nev;
        }
        public void setAzonosito(string azonosito)
        {
            this.azonosito = azonosito;
        }
        public void setTermElem(string termElem)
        {
            this.termElem = termElem;
        }
        public void setOsszStat(int osszStat)
        {
            this.osszStat = osszStat;
        }

        public int generacio()
        {
            if (this.azonosito[1] == '0')
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public bool harcol(Pokemon p)
        {
            return this.osszStat >= p.osszStat;
        }

        public void eletpontValtozas(bool gyoz)
        {
            if (gyoz)
            {
                this.osszStat += 10;
            }
            else
            {
                this.osszStat -= 10;
            }
        }

        public void eletpontValtozasMasodikEv(bool gyoz)
        {
            if (gyoz)
            {
                this.osszStat += 20;
            }
            else
            {
                this.osszStat -= 20;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", this.nev, this.azonosito, this.termElem, this.osszStat);
        }

    }
}
