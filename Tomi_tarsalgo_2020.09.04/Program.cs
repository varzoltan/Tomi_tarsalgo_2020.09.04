using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tomi_tarsalgo_2020._09._04
{
    class Program
    {
        //struktúra létrehozása
        struct Adat
        {
            public int ora;
            public int perc;
            public int azonosito;
            public string beki;
            public int bentlevok;
        }
        static void Main(string[] args)
        {
            Adat[] adatok = new Adat[1000];
            //1. Olvassa be és tárolja el az ajto.txt fájl tartalmát!
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Downloads\ajto.txt");
            int n = 0;
            int bentlevok = 0;
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                string[] db = sor.Split();
                adatok[n].ora = int.Parse(db[0]);
                adatok[n].perc = int.Parse(db[1]);
                adatok[n].azonosito = int.Parse(db[2]);
                adatok[n].beki = db[3];
                if (adatok[n].beki == "be")
                {
                    bentlevok++;
                }
                else
                {
                    bentlevok--;
                }
                adatok[n].bentlevok = bentlevok;
                n++;
            }
            Console.WriteLine("1. feladat: beolvasás kész!");
            Console.WriteLine($"{adatok[7].bentlevok}");

            Console.ReadKey();
        }
    }
}
