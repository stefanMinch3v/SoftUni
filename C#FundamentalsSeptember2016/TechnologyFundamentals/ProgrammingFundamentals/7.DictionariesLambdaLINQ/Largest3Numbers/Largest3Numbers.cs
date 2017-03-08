using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest3Numbers
{
    public class Largest3Numbers
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .OrderByDescending(x => x)
                                    .Take(3)
                                    .ToArray();
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
