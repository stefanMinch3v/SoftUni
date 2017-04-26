using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExerciseSymbols
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (!symbols.ContainsKey(input[i]))
            {
                symbols.Add(input[i], 0); // symbols.[input[i]] = 0;
            }
            symbols[input[i]]++;
        }

        foreach (var kvp in symbols)
        {
            var key = kvp.Key;
            var value = kvp.Value;
            Console.WriteLine($"{key}: {value} time/s");
        }
    }
}
