using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace justPractice
{
    class PyramidStars
    {
        static void Main(string[] args)
        {
            /*UNCOMPLETED TASK
            var n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int ii = 1; ii <= i; ii++)
                {
                    Console.Write(ii);
                    for (int iii = n - 1; iii >= 1; iii--)
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }*/
            var n = int.Parse(Console.ReadLine());
            var space = n + 1 - 1;
            for (int row = 1; row <= n; row++)
            {
                for (int i = space; i >= 1; i--)
                {
                    Console.Write(" ");
                }
                for (int ii = 1; ii <= row; ii++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
                space--;
            }
        }
    }
}
