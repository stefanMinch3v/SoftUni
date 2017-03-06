using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int ii = i; ii <= n; ii++)
                {
                    Console.Write(ii);
                }
                Console.WriteLine();
            }*/
            var n = int.Parse(Console.ReadLine());
            var num = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int ii = 1; ii <= i; ii++)
                {
                    Console.Write(num + " ");
                    num++;
                    if (num > n)
                    {
                        return;
                    }
                }
                Console.WriteLine();
                if (num > n)
                {
                    return;
                }
            }
        }
    }
}
