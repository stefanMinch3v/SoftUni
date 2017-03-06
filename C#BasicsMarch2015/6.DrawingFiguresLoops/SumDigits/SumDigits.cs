using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumDigits
{
    class SumDigits
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var sum = 0;
            var sum2 = 0;
            for (int i = num; i > 0; i--)
            {
                sum = num % 10;
                sum2 += sum;
                num /= 10;
            }
            Console.WriteLine(sum2);
        }
    }
}