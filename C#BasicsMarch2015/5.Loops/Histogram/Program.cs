using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double count1 = 0;
            double count2 = 0;
            double count3 = 0;
            double count4 = 0;
            double count5 = 0;
            double count = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                ++count;

                if (number >= 800)
                    ++count5;
                else if (number >= 600)
                    ++count4;
                else if (number >= 400)
                    ++count3;
                else if (number >= 200)
                    ++count2;
                else
                    ++count1;
            }
            Console.WriteLine("{0:0.00}%", 100 * count1 / count);
            Console.WriteLine("{0:0.00}%", 100 * count2 / count);
            Console.WriteLine("{0:0.00}%", 100 * count3 / count);
            Console.WriteLine("{0:0.00}%", 100 * count4 / count);
            Console.WriteLine("{0:0.00}%", 100 * count5 / count);

            /*
            var number = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            double count = 0;
            double count2 = 0;
            double count3 = 0;
            double count4 = 0;
            double count5 = 0;

            for (int i = 1; i <= number; i++)
            {
                var n = int.Parse(Console.ReadLine());

                if (n < 200)
                {
                    count++;
                }
                if (n >= 200 && n <= 399)
                {
                    count2++;
                }
                if (n > 399 && n <= 599)
                {
                    count3++;
                }
                if (n > 599 && n <= 799)
                {
                    count4++;
                }
                if(n > 799)
                {
                    count5++;
                }
            }

            p1 = (count / number) * 100;
            p2 = (count2 / number) * 100;
            p3 = (count3 / number) * 100;
            p4 = (count4 / number) * 100;
            p5 = (count5 / number) * 100;
            Console.WriteLine(Math.Round(p1, 2) + "%");
            Console.WriteLine(Math.Round(p2, 2) + "%");
            Console.WriteLine(Math.Round(p3, 2) + "%");
            Console.WriteLine(Math.Round(p4, 2) + "%");
            Console.WriteLine(Math.Round(p5, 2) + "%");
            */
        }
    }
}
        
        