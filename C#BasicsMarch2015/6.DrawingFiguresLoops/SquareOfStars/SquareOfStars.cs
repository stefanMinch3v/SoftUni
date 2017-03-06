using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareOfStars
{
    class SquareOfStars
    {
        static void Main(string[] args)
        {
            //variant 1
            /*var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int ii = 0; ii < n; ii++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }*/
            //variant 2
            /*
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int ii = 0; ii < (n + (n-1)); ii++)
                {
                    if (ii % 2 == 0)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }*/
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int ii = 0; ii < n + n; ii++)
                {
                    if (ii % 2 == 0)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
