using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberPyramid
{
    class NumberPyramid
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int number = 1;
            bool end = false;
            for (int i = 1; i <= n; i++)
            {
                for (int ii = 1; ii < i; ii++)
                {
                    Console.Write(number + " ");
                    number++;
                    if (number > n)
                    {
                        end = true;
                        break;
                    }
                }
                Console.WriteLine();
                if (end == true)
                { 
                    break;
                }
            }
        }
    }
}
