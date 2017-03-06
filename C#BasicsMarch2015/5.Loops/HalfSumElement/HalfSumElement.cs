using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfSumElement
{
    class HalfSumElement
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0.0;
            var maxNum = -100000000;

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                sum += num;

                if (num > maxNum)
                {
                    maxNum = num;
                }

            }

            var sumSmaller = (sum - maxNum);

            if ((sumSmaller) == maxNum)
            {
                Console.WriteLine("Yes sum " + maxNum);
            }
            else
            {
                Console.WriteLine("No diff " + Math.Abs(maxNum - sumSmaller));
            }

            /*
            var number = int.Parse(Console.ReadLine());
            var bigNumber = 0;
            var smallNumbers = 0;
            var sum = 0;
            for (int i = 1; i <= number; i++)
            {
                var n = int.Parse(Console.ReadLine());
                if (bigNumber < n)
                {
                    bigNumber = n;
                }
                smallNumbers += n;
            }
            sum = smallNumbers - bigNumber;
            Console.WriteLine(bigNumber);
            Console.WriteLine(sum);
            if (bigNumber == sum)
            {
                Console.WriteLine("Yes, Sum = {0}", bigNumber);
            }
            else
            {
                Console.WriteLine("No, Diff = {0}", Math.Abs(bigNumber - sum));
            }
            */
        }
    }
}
