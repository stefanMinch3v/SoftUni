using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareFrame
{
    class SquareFrame
    {
        static void Main(string[] args)
        {
            /*Typ variant
            var n = int.Parse(Console.ReadLine());
            Console.Write("+");
            for (var i = 1; i <= n - 2; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");
            for (var ii = 1; ii <= n - 2; ii++)
            {
                Console.Write("|");
                for (int iii = 1; iii <= n - 2; iii++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("|");
            }
            Console.Write("+");
            for (var iiii = 1; iiii <= n - 2; iiii++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");
            */
            //gotiniq variant
            var n = int.Parse(Console.ReadLine());
            int dashesCount = n - 2;
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    Console.Write("+");
                    Console.Write(new string('-', dashesCount));
                    Console.WriteLine("+");
                }
                if (i == n - 2)
                {
                    Console.Write("+");
                    Console.Write(new string('-', dashesCount));
                    Console.WriteLine("+");
                    break; //it could be either return or break
                }
                else if (i < n)
                {
                    Console.Write("|");
                    Console.Write(new string('-', dashesCount));
                    Console.WriteLine("|");
                }
            }
        }
    }
}
