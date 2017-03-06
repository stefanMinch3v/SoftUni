using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoBookPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = n; i < n + 4 ; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
