using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MinerTaskExercise
{
    public static void Main(string[] args)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        string input = Console.ReadLine();
        while (!input.Contains("stop"))
        {
            string resource = input;
            int quantity = int.Parse(Console.ReadLine());

            FillOutDictionary(resource, quantity, dic);
            input = Console.ReadLine();
        }

        foreach (var kvp in dic)
        {
            var key = kvp.Key;
            var value = kvp.Value;
            Console.WriteLine($"{key} -> {value}");
        }
    }

    private static void FillOutDictionary(string resource, int quantity, Dictionary<string, int> dic)
    {
        if (!dic.ContainsKey(resource))
        {
            dic.Add(resource, quantity);
        }
        else
        {
            dic[resource] += quantity;
        }
    }
}
