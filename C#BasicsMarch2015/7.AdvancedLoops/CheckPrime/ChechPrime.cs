using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPrime
{
    class ChechPrime
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            bool isPrime = true;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            Console.WriteLine(isPrime);
        }
    }
}
