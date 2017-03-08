using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortWordsSorted
{
    class ShortWordsSorted
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                                        .ToLower()
                                        .Split(new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '\"', '\'', '\\', '/', '!', '?', ' ', })
                                        .Where(x => x.Length < 5)
                                        .OrderBy(x => x)
                                        .Distinct()
                                        .ToArray();
            Console.WriteLine(string.Join(", ", input));
        }
    }
}
