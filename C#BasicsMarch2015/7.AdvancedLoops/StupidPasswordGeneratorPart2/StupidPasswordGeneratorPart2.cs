using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidPasswordGeneratorPart2
{
    class StupidPasswordGeneratorPart2
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var l = int.Parse(Console.ReadLine());

            for (char digit1 = '1'; digit1 <= '1' + n; digit1++)
            {
                for (char digit2 = '1'; digit2 <= '1' + n; digit2++)
                {
                    for (char letter1 = 'a'; letter1 < 'a' + l; letter1++)
                    {
                        for (char letter2 = 'a'; letter2 < 'a' + l; letter2++)
                        {
                            for (char digit3 = (char)(Math.Max(digit1, digit2) + 1); digit3 < '1' + n; digit3++)
                            {
                                Console.Write("" + digit1 + digit2 + letter1 + letter2 + digit3 + " ");
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
