using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurrences
{
    public class OddOccurrences
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower().Split().ToArray();
            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (var inputer in input)
            {
                if (words.ContainsKey(inputer))
                {
                    words[inputer]++;
                }
                else
                {
                    words[inputer] = 1;
                }
            }

            List<string> counts = new List<string>();

            foreach (var word in words)
            {
                if (word.Value % 2 != 0)
                {
                    counts.Add(word.Key);
                }
            }

            Console.WriteLine(string.Join(", ", counts));
        }
    }
}
