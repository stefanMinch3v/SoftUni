using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axe
{
    class Axe
    {
        static void Main(string[] args)
        {
            /*
            var a = int.Parse(Console.ReadLine());
            for (int i = 1; i <= a; i++)
            {
                for (int ii = 1; ii <= i; ii++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }*/

            string name = Console.ReadLine();
            
            
            return;
            /*var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < 2 * n; i++)
            {
                Console.WriteLine("{0}{1}{0}",new string('-', 2 * n), new string('*', n ), new string('-', 3 * n));
            }*/
            var n = int.Parse(Console.ReadLine());
            var width = 5 * n;
            var leftDashes = 3 * n;
            var middleDashes = 0;
            var rightDashes = width - leftDashes - middleDashes - 2;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}*{1}*{2}",
                    new string('-', leftDashes),
                    new string('-', middleDashes),
                    new string('-', rightDashes));
                middleDashes++;
                rightDashes--;
            }

            middleDashes--;
            rightDashes++;
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}*{1}*{2}",
                    new string('*', leftDashes),
                    new string('-', middleDashes),
                    new string('-', rightDashes));
            }

            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.WriteLine("{0}*{1}*{2}",
                    new string('-', leftDashes),
                    new string('-', middleDashes),
                    new string('-', rightDashes));
                leftDashes--;
                middleDashes += 2;
                rightDashes--;
            }
            Console.WriteLine("{0}*{1}*{2}",
                    new string('-', leftDashes),
                    new string('*', middleDashes),
                    new string('-', rightDashes));
        }
    }
}
