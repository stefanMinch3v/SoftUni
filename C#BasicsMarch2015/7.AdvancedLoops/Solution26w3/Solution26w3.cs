using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution26w3
{
    class Solution26w3
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum = (sum * 10) + 1;
                Console.Write("{0} + ", sum);
                
            }
            Console.WriteLine();
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i);
            }
        }
    }
}
