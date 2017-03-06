using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingProgramer
{
    class TravellingProgramer
    {
        static void Main(string[] args)
        {
            var num = double.Parse(Console.ReadLine());
            var season = Console.ReadLine();
            if (num <= 100)
            {
                Console.WriteLine("Somewhere in Bulgaria");
                if (season == "summer")
                {
                    Console.WriteLine("Camp - {0:f2}", (num * 30) / 100);
                }
                else if (season == "winter")
                {
                    Console.WriteLine("Hotel - {0:f2}", (num *70) / 100);
                }
            }
            else if (num <= 1000)
            {
                Console.WriteLine("Somewhere in Balkans");
                if (season == "summer")
                {
                    Console.WriteLine("Camp - {0:f2}", (num * 40) / 100);
                }
                else if (season == "winter")
                {
                    Console.WriteLine("Hotel - {0:f2}", (num * 80) / 100);
                }
            }
            else
            {
                Console.WriteLine("Somewhere in Europe");
                if (season == "winter" || season == "summer")
                {
                    Console.WriteLine("Hotel - {0:f2}", (num * 90) / 100);
                }
            }
        }
    }
}
