using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButterflyProblem
{
    class ButterflyProblem
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n - 2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(new string('*', n - 2));
                    Console.Write("\\ /");
                    Console.Write(new string('*', n - 2));
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(new string('-', n - 2));
                    Console.Write("\\ /");
                    Console.Write(new string('-', n - 2));
                    Console.WriteLine();
                }
            }
            Console.WriteLine("{0}{1}{0}",new string(' ', n - 1), "@");
            for (int i = 0; i < n - 2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(new string('*', n - 2));
                    Console.Write("/ \\");
                    Console.Write(new string('*', n - 2));
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(new string('-', n - 2));
                    Console.Write("/ \\");
                    Console.Write(new string('-', n - 2));
                    Console.WriteLine();
                }
            }
        }
    }
}
