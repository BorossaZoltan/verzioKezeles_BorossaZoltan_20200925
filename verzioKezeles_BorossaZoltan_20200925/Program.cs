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

        static void Main(string[] args)
        {
            

            harcosok = new List<Harcos>() {new Harcos("Szabi", 2) , new Harcos("Zsombi", 1), new Harcos("Zoli", 3) };
            beolvas("harcosok.csv");
            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine(harcosok[i]);
            }
            Console.ReadKey();
        }
    }
}
