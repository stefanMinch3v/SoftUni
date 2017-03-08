using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairsByDifference
{
    class PairsByDifference
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());
            int countPair = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int ii = i; ii < input.Length; ii++)
                {
                    var sum = (input[i] - input[ii]);
                    if (Math.Abs(sum) == k)
                    {
                        countPair++;
                    }
                }
            }

            Console.WriteLine(countPair);
        }
    }
}
