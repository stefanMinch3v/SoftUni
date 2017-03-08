using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> results = new Dictionary<string, int>();
            string[] words = File.ReadAllText("words.txt").ToLower().Split();
            string[] text = File.ReadAllText("text.txt").ToLower().Split(new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in words)
            {
                results[item] = 0;
            }

            foreach (var item in text)
            {
                if (results.ContainsKey(item))
                {
                    results[item]++;
                }
            }

            var finalResult = results.OrderByDescending(c => c.Value);
            //results = results.OrderByDescending(c => c.Value).ToDictionary(x => x.Key, x => x.Value); second way to create dictionary
            foreach (var item in finalResult)
            {
                File.AppendAllText("output.txt", $"{item.Key} - {item.Value}\r\n");
            }
        }
    }
}
