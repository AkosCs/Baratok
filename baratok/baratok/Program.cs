using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace baratok
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines("baratok.txt");
            bool elsoNev = true;
            bool elsoBarat = true;
            string nevek_str = "";
            string baratok_str = "";
            for (int i = 0; i < file.Length; i++)
            {
                string sor = file[i];
                if (!String.IsNullOrEmpty(sor))
                {
                    if(elsoNev)
                    {
                        if (nevek_str != "") nevek_str += ";";
                        nevek_str += sor;
                        elsoNev = false;
                        

                    }
                    else
                    {
                        if (!elsoBarat) baratok_str += ";";
                        baratok_str += sor;
                        elsoBarat = false;
                    }

                }
                else
                {
                    elsoNev = true;
                    elsoBarat = true;
                    baratok_str += "\n";


                }

            }

            string[] nevek = nevek_str.Split(';');
            string[][] baratok = new string[nevek.Length][];
            string[] b = baratok_str.Split('\n');
            for (int i = 0; i < nevek.Length; i++)
            {
                baratok[i] = b[i].Split(';');

            }
            Console.WriteLine(baratok_str);
            int maxIndex = 0;

            for (int i = 1; i < baratok.Length; i++)
            {
                if(baratok[i].Length>baratok[maxIndex].Length)
                {
                    maxIndex = i;
                }
            }

            
        Console.WriteLine($"A legtöbb barátja {nevek[maxIndex]} nak/nek van. {baratok[maxIndex].Length} db");

            foreach(string barat in baratok[maxIndex])
            {
                Console.WriteLine(barat);
            }
            Console.ReadLine();

            
        }
    }
}
