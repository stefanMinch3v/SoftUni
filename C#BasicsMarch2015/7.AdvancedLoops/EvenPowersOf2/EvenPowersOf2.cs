using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenPowersOf2
{
    class EvenPowersOf2
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int num = 1;
            for (int i = 0; i <= n; i+=2)
            {
                Console.WriteLine(num);
                num = num * 2 * 2;
            }
        }
    }
}
