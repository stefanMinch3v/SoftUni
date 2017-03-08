using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatinLetters
{
    class LatinLetters
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                for (int ii = 0; ii < num; ii++)
                {
                    for (int iii = 0; iii < num; iii++)
                    {
                        char letter = (char)('a' + i);
                        char letter2 = (char)('a' + ii);
                        char letter3 = (char)('a' + iii);
                        Console.WriteLine("{0}{1}{2}", letter, letter2, letter3);
                    }
                }
            }
        }
    }
}
