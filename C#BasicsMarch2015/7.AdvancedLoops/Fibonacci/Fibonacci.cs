using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Fibonacci
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var fib0 = 1;
            var fib1 = 1;
            for (int i = 0; i < n - 1; i++)
            {
                var fNext = fib0 + fib1;
                fib0 = fib1;
                fib1 = fNext;
            }
            Console.WriteLine(fib1);
        }
    }
}
