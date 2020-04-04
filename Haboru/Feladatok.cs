using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Timers;
using System.Threading;

namespace Haboru
{
    class Feladatok
    {
        private List<Pokemon> pokemonok;
        private List<Fertozott> fertozottek;
        private List<Pokemon> egeszsegesek;
        private static Random r = new Random();
        private string bevitel;
        private Dictionary<string, int> kezdetiOsszStat = new Dictionary<string, int>();

        public string Bevitel { get => bevitel; set => bevitel = value; }

        public void fajlBeolvasas()
        {
            try
            {
                pokemonok = new List<Pokemon>();
                StreamReader r = new StreamReader("pokemons.txt", Encoding.UTF8);
                string elsoSor = r.ReadLine();
                while (!r.EndOfStream)
                {
                    String sor = r.ReadLine();
                    string[] st = sor.Split(';');
                    string nev = st[0];
                    string azonosito = st[1];
                    string termElem = st[2];
                    int osszStat = int.Parse(st[3]);
                    pokemonok.Add(new Pokemon(nev, azonosito, termElem, osszStat));
                }
                foreach (var item in pokemonok)
                {
                    Console.WriteLine(item);
                    kezdetiOsszStat.Add(item.getNev(), item.getOsszStat());
                }
                r.Close();
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

        public void virusKitores()
        {
            egeszsegesek = new List<Pokemon>();
            fertozottek = new List<Fertozott>();
            foreach (var item in pokemonok)
            {
                if (item.getTermElem().Contains("Normal") ||
                    item.getTermElem().Contains("Pszicho") ||
                    item.getTermElem().Contains("Sarkany"))
                {
                    fertozottek.Add(new Fertozott(item.getNev(), item.getAzonosito(), item.getTermElem(), item.getOsszStat()));
                }
                else
                {
                    egeszsegesek.Add(new Fertozott(item.getNev(), item.getAzonosito(), item.getTermElem(), item.getOsszStat()));
                }
            }
            Console.WriteLine("\n\n\nEgészségesek:");
            foreach (var item in egeszsegesek)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nFertőzöttek:");
            foreach (var item in fertozottek)
            {
                Console.WriteLine(item);
            }
        }

        public void haboruElsoEv()
        {
            for (int i = 0; i < 15; i++)
            {
                int fertozottIndex = r.Next(0, fertozottek.Count);
                int egeszsegesIndex = r.Next(0, egeszsegesek.Count);
                bool l = fertozottek[fertozottIndex].harcol(egeszsegesek[egeszsegesIndex]);
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

        public void bekeres()
        {
            do
            {               
                try
                {
                    ClearLastLine();                 
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    Console.Write("\n\n\tKérem adja meg a helyes választ: ");
                    Bevitel = Console.ReadLine();
                    while (Bevitel.Length > 3 || Bevitel.Length <= 2)
                    {
                        MessageBox.Show("Hiba, érvénytelen bevitel!");
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            } 
            while (Bevitel.Length > 3 || Bevitel.Length <= 2);            
        }

        public void jelentes(string id)
        {
            foreach (var item in egeszsegesek)
            {
                if (item.getAzonosito().Equals(id))
                {
                    if (kezdetiOsszStat[item.getNev()] < item.getOsszStat())
                    {
                        Console.WriteLine("{0} ,egészséges, kezdeti össz stat: {1} , össz stat változás: +{2}",
                        item.getNev(), kezdetiOsszStat[item.getNev()], Math.Abs(kezdetiOsszStat[item.getNev()] - item.getOsszStat()));
                    }
                    else
                    {
                        Console.WriteLine("{0} ,egészséges, kezdeti össz stat: {1} , össz stat változás: {2}",
                        item.getNev(), kezdetiOsszStat[item.getNev()], (-1)*(kezdetiOsszStat[item.getNev()] - item.getOsszStat()));
                    }                   
                }
            }
            foreach (var item in fertozottek)
            {
                if (item.getAzonosito().Equals(id))
                {
                    if (kezdetiOsszStat[item.getNev()] < item.getOsszStat())
                    {
                        Console.WriteLine("{0} ,fertőzött, kezdeti össz stat: {1} , össz stat változás: +{2}",
                        item.getNev(), kezdetiOsszStat[item.getNev()], Math.Abs(kezdetiOsszStat[item.getNev()] - item.getOsszStat()));
                    }
                    else
                    {
                        Console.WriteLine("{0} ,fertőzött, kezdeti össz stat: {1} , össz stat változás: {2}",
                        item.getNev(), kezdetiOsszStat[item.getNev()], (-1) * (kezdetiOsszStat[item.getNev()] - item.getOsszStat()));
                    }
                }
            }
        }


        public static void ClearLastLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}
