using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenPosition
{
    class OddEvenPosition
    {
        static void Main(string[] args)
        {
            var n = float.Parse(Console.ReadLine());
            var oddsum = 0.0;
            var oddmin = double.MaxValue;
            var oddmax = double.MinValue;
            var evensum = 0.0;
            var evenmin = double.MaxValue;
            var evenmax = double.MinValue;
            for (int i = 1; i <= n; i++)
            {
                var num = double.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                    oddsum += num;
                    if (num < oddmin)
                    {
                        oddmin = num;
                    }
                    if (num > oddmax)
                    {
                        oddmax = num;
                    }
                }
                else 
                {
                    evensum += num;
                    if (num < evenmin)
                    {
                        evenmin = num;
                    }
                    if (num > evenmax)
                    {
                        evenmax = num;
                    }
                }
            }
            if (n == 0)
            {
                Console.WriteLine("Oddsum = 0");
                Console.WriteLine("Oddmin = No");
                Console.WriteLine("Oddmax = No");
                Console.WriteLine("Evensum = 0");
                Console.WriteLine("Evenmin = No");
                Console.WriteLine("Evenmax = No");
            }
            else if (n == 1)
            {
                Console.WriteLine("Oddsum = {0}", oddsum);
                Console.WriteLine("Oddmin = {0}", oddmin);
                Console.WriteLine("Oddmax = {0}", oddmin);
                Console.WriteLine("Evensum = 0");
                Console.WriteLine("Evenmin = No");
                Console.WriteLine("Evenmax = No");
            }
            else
            {
                Console.WriteLine("Oddsum = {0}", oddsum);
                Console.WriteLine("Oddmin = {0}", oddmin);
                Console.WriteLine("Oddmax = {0}", oddmax);
                Console.WriteLine("Evensum = {0}", evensum);
                Console.WriteLine("Evenmin = {0}", evenmin);
                Console.WriteLine("Evenmax = {0}", evenmax);
            }
        }
    }
}
