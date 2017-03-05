using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedInfo
{
    class SpeedInfo
    {
        static void Main(string[] args)
        {
            Console.Write("Enter some speed: ");
            var num = float.Parse(Console.ReadLine());
            if (num <= 10)
            {
                Console.WriteLine("slow");
            }
            else if (num > 10 && num <= 50)
            {
                Console.WriteLine("average");
            }
            else if (num > 50 && num <= 150)
            {
                Console.WriteLine("fast");
            }
            else if (num > 150 && num <= 1000)
            {
                Console.WriteLine("ultra fast");
            }
            else if (num > 1000)
            {
                Console.WriteLine("extremely fast");
            }
        }
    }
}
