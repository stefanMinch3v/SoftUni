using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleOfDollars
{
    class TriangleOfDollars
    {
        static void Main(string[] args)
        {
            /*
            var n = int.Parse(Console.ReadLine());
            for (var row = 1; row <= n; row++)
            {
                Console.Write("$");
                for (var cols = 1; cols < row; cols++)
                {
                    Console.Write("$");
                }
                Console.WriteLine();
            }*/
            var n = int.Parse(Console.ReadLine());
            for (var row = 1; row <= n; row++)
            {
                Console.Write("$");
                for (var col = 1; col < row; col++)
                {
                    Console.Write("$");
                }
                Console.WriteLine();
            }
        }
    }
}
