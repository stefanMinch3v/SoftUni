using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        Action<string[]> myActions = PrintAllNames;
        myActions(input);
    }

    private static void PrintAllNames(string[] input)
    {
        foreach (var name in input)
        {
            Console.WriteLine($"Sir {name}");
        }
    }
}
