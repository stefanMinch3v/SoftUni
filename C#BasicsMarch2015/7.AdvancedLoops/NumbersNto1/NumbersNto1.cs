using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersNto1
{
    class NumbersNto1
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            for (int i = num; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
