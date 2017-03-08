using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BigFactorial
{
    class BigFactorial
    {
        static void Main(string[] args)
        {
            var input = decimal.Parse(Console.ReadLine());
            BigInteger factorial = 1;

            for (int i = 1; i <= input; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);
        }
    }
}
