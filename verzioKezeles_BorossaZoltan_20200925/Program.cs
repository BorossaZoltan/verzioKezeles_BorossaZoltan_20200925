using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Program
    {
        public static List<Harcos> harcosok;
        static void beolvas(string fajl)
        {
            StreamReader sr = new StreamReader(fajl);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                harcosok.Add(new Harcos(sor[0], Convert.ToInt32(sor[1])));
            }
            sr.Close();
        }

        public static Harcos felhasznaloLetrehozas()
        {
            string felhasznaloNev;
            int statusz;
            Console.WriteLine("Adja meg a karaktere felhasználó nevét!");
            felhasznaloNev = Console.ReadLine();
            Console.WriteLine("Adja meg a karaktere státusz sablonját!");
            Console.WriteLine("1.\t HP:18/18 - DMG: 4\n" +
                "2.\t HP:15/15 - DMG: 5\n" +
                "3.\t HP:11/11 - DMG: 6\n");
            do
            {
                statusz = Convert.ToInt32(Console.ReadLine());
                if (statusz>3 || statusz<1)
                {
                    Console.WriteLine("HIBÁS adat!");
                }
            } while (!(statusz >0 && statusz<4));
            
            return new Harcos(felhasznaloNev, statusz);
        }

        public static void osszesHarcosKiir()
        {
            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine((i+1)+".\t"+harcosok[i]);
            }
        }

        public static string betujel = " ";
        public static void menu()
        {
            
            Console.WriteLine("Mit szeretnél tenni? (üsse be a megfelelő betűjelet)");
            Console.WriteLine("\ta.) Megküzdeni egy harcossal" +
                "\n\tb.) Gyógyulni" +
                "\n\tc.) Kilépni");
            do
            {
                betujel = Console.ReadLine();

                if (!(betujel.Equals("a")|| betujel.Equals("b") || betujel.Equals("c")))
                {
                    Console.WriteLine("Nincs ilyen menüpont, adja meg újra!");
                }
                if (betujel.Equals("a"))
                {
                    int melyikHarcos = 0;
                    do
                    {
                        Console.WriteLine("Melyik harcossal szeretne megküzdeni?");
                        melyikHarcos = Convert.ToInt32(Console.ReadLine());


                        if (melyikHarcos > harcosok.Count || melyikHarcos<1)
                        {
                            Console.WriteLine("Nincs ilyen sorszámú harcos");
                        }
                        else
                        {
                            harcosok[harcosok.Count - 1].Megkuzd(harcosok[melyikHarcos-1]);
                        }

                    } while (!(melyikHarcos > 0 && melyikHarcos < harcosok.Count-1));
                }
                if (betujel.Equals("b"))
                {
                    harcosok[harcosok.Count - 1].Gyogyul();
                }


            } while (!(betujel=="a" || betujel =="b" || betujel == "c"));


        }

        static void Main(string[] args)
        {
            harcosok = new List<Harcos>() {new Harcos("Szabi", 2) , new Harcos("Zsombi", 1), new Harcos("Zoli", 3) };
            beolvas("harcosok.csv");
            
            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine(harcosok[i]);
            }

            harcosok.Add(felhasznaloLetrehozas());
            Console.WriteLine(harcosok[harcosok.Count-1]);
            do
            {
                osszesHarcosKiir();
                menu();
            } while (betujel!="c");
            


            Console.ReadKey();
        }
    }
}
