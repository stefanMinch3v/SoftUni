using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split();
        List<string> results = new List<string>();

        results = Functions.ApplyFuncNames(names, x => x, number);
        Functions.Print(results, x => Console.WriteLine(string.Join("\n", x)));

    }
}

public class Functions
{
    public static List<string> ApplyFuncNames(string[] collection, Func<string, string> myFunc, int number)
    {
        List<string> results = new List<string>();
        foreach (var name in collection)
        {
            if (name.Length <= number)
            {
                string saveName = myFunc(name);
                results.Add(saveName);
            }
        }

        return results;
    }

    public static void Print(List<string> collection, Action<List<string>> myAct)
    {
        myAct(collection);
    }
}
