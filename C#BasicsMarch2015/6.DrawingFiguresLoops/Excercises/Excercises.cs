using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercises
{
    class Excercises
    {
        static void Main(string[] args)
        {
            //edno
            /*var n = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('*', n));
            for (int i = 0; i < n-2; i++)
            {
                Console.Write('*');
                Console.Write(new string('-', n-2));
                Console.WriteLine('*');
            }
            Console.WriteLine(new string('*', n));*/
            //dve
            /*
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                if (i == 0 || i == n - 1)
                {
                    Console.WriteLine(new string('*', n));
                }
                else
                {
                    Console.Write('*');
                    Console.Write(new string('-', n-2));
                    Console.WriteLine('*');
                }
            }*/
            //tri
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int ii = 0; ii < n; ii++)
                {
                    if (i == 0 || i == n-1)
                    {
                        Console.Write('*');
                    }
                    else if (ii == 0 || ii == n-1)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('-');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
