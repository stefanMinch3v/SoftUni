using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberInRange1to100
{
    class NumberInRange1to100
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            while (n < 1 || n > 100)
            {
                Console.WriteLine("Invalid number!");
                n = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The number is: {0}", n);
        }
    }
}
