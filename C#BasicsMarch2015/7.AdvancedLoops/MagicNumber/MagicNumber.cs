using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicNumber
{
    class MagicNumber
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < 9; i++)
            {
                for (int f = 0; f < 9; f++)
                {
                    for (int g = 0; g < 9; g++)
                    {
                        for (int h = 0; h < 9; h++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                for (int k = 0; k < 9; k++)
                                {
                                    if (i * f * g * h * j * k == n)
                                    {
                                        Console.Write("{0}{1}{2}{3}{4}{5} ", i, f, g, h, j, k);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
