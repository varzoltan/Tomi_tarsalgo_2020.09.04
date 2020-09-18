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
            //Console.WriteLine($"{adatok[7].bentlevok}");

            //Írja a képernyőre annak a személynek az azonosítóját, aki a vizsgált időszakon belül először
            //lépett be az ajtón, és azét, aki utoljára távozott a megfigyelési időszakban!
            Console.Write($"Az ajtón először {adatok[0].azonosito} lépettbe, ");
            int k = 0;
            for (int i = 0;i<n;i++)
            {
                if (adatok[i].beki == "ki")
                {
                    k = i;
                }
            }
            Console.Write($"utoljára a {adatok[k].azonosito} azonosítóju személy távozott.");

            //3. Határozza meg a fájlban szereplő személyek közül, 
            //ki hányszor haladt át a társalgó ajtaján!
            StreamWriter ir = new StreamWriter(@"C:\Users\Rendszergazda\Downloads\athaladas.txt");
            
            for (int i = 1;i<101;i++)
            {
                int athalad = 0;
                for (int j = 0;j<n;j++)
                {
                    if (adatok[j].azonosito == i)
                    {
                        athalad++;
                    }
                }
                ir.WriteLine($"{i} {athalad}");
            }
            ir.Close();

            //5.feladat: Hányan voltak legtöbben egyszerre a társalgóban? 
            //Írjon a képernyőre egy olyan időpontot (óra: perc), amikor a legtöbben voltak bent!
            int max = adatok[0].bentlevok, l=0;
            for (int i = 1;i<n;i++)
            {
                if (adatok[i].bentlevok > max)
                {
                    max = adatok[i].bentlevok;
                    l = i;
                }
            }
            Console.WriteLine($"\nPéldául {adatok[l].ora}:{adatok[l].perc}-kor voltak a legtöbben a társalgóban.");

            //6. Kérje be a felhasználótól egy személy azonosítóját! 
            //A további feladatok megoldásánál ezt használja fel!
            Console.WriteLine("Kérem adjon meg egy azonosítót: ");
            int azon = int.Parse(Console.ReadLine());

            //7. Írja a képernyőre, hogy a beolvasott azonosítóhoz tartozó személy mettől meddig
            //tartózkodott a társalgóban!
            for (int i = 0;i<n;i++)
            {
                if (azon == adatok[i].azonosito)
                {
                    if ("be" == adatok[i].beki)
                    {
                        Console.Write($"{adatok[i].ora}:{adatok[i].perc}-");
                    }
                    else
                    {
                        Console.WriteLine($"{adatok[i].ora}:{adatok[i].perc}");
                    }
                }
            }

            //8. feladat
            int osszegzes = 0;
            int osszegzes1 = 0;
            int osszegzes2 = 0;
            for (int i = 0; i < n; i++)
            {
                if (azon == adatok[i].azonosito)
                {
                    if ("be" == adatok[i].beki)
                    {
                        osszegzes = Ora_perc(adatok[i].ora, adatok[i].perc);
                    }
                    else
                    {
                        osszegzes1 = Ora_perc(adatok[i].ora, adatok[i].perc);
                        osszegzes2 += osszegzes1 - osszegzes;
                    }
                    
                }
            }

            Console.WriteLine($"A(z) {azon}. személy összesen {osszegzes2} percet volt bent, a megfigyelés végén a társalgóban volt.");
            Console.ReadKey();
        }


        //Függvény
        static int Ora_perc(int ora,int perc)
        {
            return ora * 60 + perc;
        }

    }
}
