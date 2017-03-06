using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFort
{
    class DrawFort
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int cols = 2 * n;
            int baseMetric = n / 2;

            //Top of the fort
            Console.WriteLine("/{0}\\{1}/{0}\\",
                new string('^', baseMetric), new string('_', cols - (baseMetric * 2 + 4)));

            for (int i = 0; i < n - 2; i++)
            {
                //Main side of the fort

                char middlePart = ' ';
                if (i == n - 3)
                {
                    middlePart = '_';
                }

                Console.WriteLine("|{0}{1}{0}|",
                    new string(' ', baseMetric + 1), 
                    new string(middlePart, cols - (baseMetric * 2 + 4)));
            }

            //Footer of the fort
            Console.WriteLine("\\{0}/{1}\\{0}/",
                new string('_', baseMetric), new string(' ', cols - (baseMetric * 2 + 4)));
        }
    }
}
