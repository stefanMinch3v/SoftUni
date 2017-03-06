using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidPasswordGenerator
{
    class StupidPasswordGenerator
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var l = int.Parse(Console.ReadLine());
            for (int a = 1; a <= n; a++)
            {
                for (int b = 1; b <= n; b++)
                {
                    for (char c = 'a'; c < 'a' + 1; c++)
                    {
                        for (char d = 'a'; d < 'a' + 1; d++)
                        {
                            for (int e = 1; e <= n; e++)
                            {
                                if (e > b && e > a)
                                {
                                    Console.Write("{0}{1}{2}{3}{4} ", a, b, c, d, e);
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
