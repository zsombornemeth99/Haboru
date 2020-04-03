using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haboru
{
    class Feladatok
    {
        private List<Pokemon> pokemonok;
        private List<Pokemon> fertozottek;
        private List<Pokemon> egeszsegesek;
        private static Random r = new Random();

        public void FajlBeolvasas()
        {
            try
            {
                pokemonok = new List<Pokemon>();
                StreamReader olvas = new StreamReader("pokemons.txt", Encoding.UTF8);
                string elsoSor = olvas.ReadLine();
                while (!olvas.EndOfStream)
                {
                    String sor = olvas.ReadLine();
                    string[] st = sor.Split(';');
                    string nev = st[0];
                    string azonosito = st[1];
                    string termElem = st[2];
                    int osszStat = Convert.ToInt32(st[3]);
                    pokemonok.Add(new Pokemon(nev, azonosito, termElem, osszStat));
                }
                foreach (Pokemon p in pokemonok)
                {
                    Console.WriteLine(p);
                }
                olvas.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("A fájl nem található");
            }
            catch (IOException)
            {
                Console.WriteLine("Írási/olvasási hiba!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Hiba: "+e);
            }

        }
        public void VirusKitores()
        {
            egeszsegesek = new List<Pokemon>();
            fertozottek = new List<Pokemon>();
            foreach (Pokemon p in pokemonok)
            {
                if (p.getTermElem().Contains("Normal") ||
                    p.getTermElem().Contains("Pszicho") ||
                    p.getTermElem().Contains("Sarkany"))
                {
                    fertozottek.Add(new Fertozott(p.getNev(), p.getAzonosito(), p.getTermElem(), p.getOsszStat()));
                }
                else
                {
                    egeszsegesek.Add(new Fertozott(p.getNev(), p.getAzonosito(), p.getTermElem(), p.getOsszStat()));
                }
            }
            Console.WriteLine("\n\n\nEgészségesek:");
            foreach (Pokemon e in egeszsegesek)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("\nFertőzöttek:");
            foreach (Pokemon f in fertozottek)
            {
                Console.WriteLine(f);
            }
        }
        public void HaboruElsoEv()
        {
            for (int i = 0; i < 15; i++)
            {
                int fertozottIndex = r.Next(0, fertozottek.Count);
                int egeszsegesIndex = r.Next(0, egeszsegesek.Count);
                bool l = fertozottek[fertozottIndex].Harcol(egeszsegesek[egeszsegesIndex]);
                fertozottek[fertozottIndex].eletpontValtozas(l);
                egeszsegesek[egeszsegesIndex].eletpontValtozas(l);
            }
            Console.WriteLine("\n\n\nEgészségesek változása:");
            foreach (Pokemon e in egeszsegesek)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("\nFertőzöttek változása:");
            foreach (Pokemon f in fertozottek)
            {
                Console.WriteLine(f);
            }
        }
    }
}
