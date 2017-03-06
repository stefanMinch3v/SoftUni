using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftAndRightSum
{
    class LeftAndRightSum
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter n: ");
            //var n = int.Parse(Console.ReadLine());
            //var sum = 0;
            //for (int i = 0; i < n; i++)
            //{
            //sum += int.Parse(Console.ReadLine());
            //}
            // Console.Write("Enter n1: ");
            //var n1 = int.Parse(Console.ReadLine());
            //var sum1 = 0;
            //for (int i = 0; i < n1; i++)
            // {
            // sum1 += int.Parse(Console.ReadLine());
            // }
            //if (sum == sum1)
            //{
            // Console.WriteLine("Yes, sum = " + sum);
            //}
            // else
            // {
            // Console.WriteLine("No, diff = " + Math.Abs(sum - sum1));
            //}
            //Vtori variant
            var n = int.Parse(Console.ReadLine());
            var sum = 0;
            var sum1 = 0;
            for (int i = 0; i < 2 * n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (i < n)
                {
                    sum += num;
                }
                else
                {
                    sum1 += num;
                }
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
