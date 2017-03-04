using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int ii = i; ii <= n; ii++)
                {
                    Console.Write(ii);
                }
                Console.WriteLine();
            }*/
            var n = int.Parse(Console.ReadLine());
            Console.Write("+ ");
            for (var i = 1; i <= n - 2; i++)
            {
                Console.Write("- ");
            }
            Console.WriteLine("+");
            for (var ii = 1; ii <= n - 2; ii++)
            {
                Console.Write("| ");
                for (int iii = 1; iii <= n - 2; iii++)
                {
                    Console.Write("- ");
                }
                Console.WriteLine("|");
            }
            Console.Write("+ ");
            for (var iiii = 1; iiii <= n - 2; iiii++)
            {
                Console.Write("- ");
            }
            Console.WriteLine("+");
        }
    }
}