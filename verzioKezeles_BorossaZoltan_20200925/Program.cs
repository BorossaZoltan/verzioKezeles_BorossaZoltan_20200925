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

        public static void felhasznaloLetrehozas()
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
        }

        static void Main(string[] args)
        {
            

            harcosok = new List<Harcos>() {new Harcos("Szabi", 2) , new Harcos("Zsombi", 1), new Harcos("Zoli", 3) };
            beolvas("harcosok.csv");
            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine(harcosok[i]);
            }

            felhasznaloLetrehozas();
            Console.ReadKey();
        }
    }
}
