using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenSum
{
    class OddEvenSum
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n: ");
            var n = int.Parse(Console.ReadLine());
            var sum = 0;
            var sum1 = 0;
            for (var i = 0; i < n; i++)
            {
                var readnum = int.Parse(Console.ReadLine());
                if (i % 2 == 0) sum += readnum;
                else sum1 += readnum;
            }

            if (sum == sum1)
            {
                Console.WriteLine("Yes, sum = " + sum);
            }
            else
            {
                Console.WriteLine("No, diff = " + Math.Abs(sum - sum1));
            }
        }
    }
}
