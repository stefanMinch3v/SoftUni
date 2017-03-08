using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentNumber
{
    class MostFrequentNumber
    {
        static void Main(string[] args)
        {
            /*string[] input = Console.ReadLine().Split().ToArray();
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var item in input)
            {
                if (! result.ContainsKey(item))
                {
                    result.Add(item, 0);
                }
                else
                {
                    result[item]++;
                }
            }

            var final = result.Aggregate( (l, r) => l.Value > r.Value ? l : r).Key;
            Console.WriteLine(final); 80/100 judge */

            //int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] input = File.ReadAllText("input.txt").Split().Select(int.Parse).ToArray();
            //string[] words = File.ReadAllText("words.txt").ToLower().Split();
            int number = 0;
            int maxNumber = 0;
            int count = 0;
            int maxCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                    {
                        number = input[i];
                        count++;
                    }
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    maxNumber = number;
                    //number = 0;
                }

                count = 0;
            }
            File.AppendAllText("output.txt", maxNumber.ToString());
            //Console.WriteLine(maxNumber);
        }
    }
}
