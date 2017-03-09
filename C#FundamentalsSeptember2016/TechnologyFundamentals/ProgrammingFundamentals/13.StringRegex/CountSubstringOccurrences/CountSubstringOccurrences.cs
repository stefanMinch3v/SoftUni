using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSubstringOccurrences
{
    class CountSubstringOccurrences
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            string word = Console.ReadLine().ToLower();
            int counter = 0;

            int index = input.IndexOf(word);

            while(index != -1)
            {
                if (input.Contains(word))
                {
                    counter++;
                    index = input.IndexOf(word, index + 1);
                }
                
            }

            Console.WriteLine(counter);
        }
    }
}
