using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main(string[] args)
    {
        var readText = File.ReadAllText("02_OddLines/text1.txt").Split();
        string[] readWord = File.ReadAllText("02_OddLines/words1.txt").Split();
        Dictionary<string, int> countWords = new Dictionary<string, int>();
        foreach (var word in readWord)
        {
            countWords.Add(word, 0);
        }
        foreach (var wCounter in readText)
        {
            if (countWords.ContainsKey(wCounter))
            {
                countWords[wCounter]++;
            }
        }
        var descendingOrder = countWords.OrderByDescending(key => key.Key);
        foreach (var kvp in descendingOrder)
        {
            var key = kvp.Key + " -> ";
            var value = kvp.Value;
            File.AppendAllText("02_OddLines/test.txt", key + value + Environment.NewLine);
        }
    }
}
