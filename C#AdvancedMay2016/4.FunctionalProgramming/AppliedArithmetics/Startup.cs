using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
        string command = Console.ReadLine();

        while (!command.Equals("end"))
        {
            switch (command)
            {
                case "add":
                    input = Functions.ApplyFunc(input, x => x + 1);
                    break;
                case "multiply":
                    input = Functions.ApplyFunc(input, x => x * 2);
                    break;
                case "subtract":
                    input = Functions.ApplyFunc(input, x => x - 1);
                    break;
                case "print":
                    Functions.Print(input, x => Console.WriteLine(string.Join(" ", input)));
                    break;
                default:
                    break;
            }

            command = Console.ReadLine();
        }
    }
}

public class Functions
{
    public static List<int> ApplyFunc(List<int> collection, Func<int, int> myFunc)
    {
        List<int> result = new List<int>();
        foreach (var item in collection)
        {
            int results = myFunc(item);
            result.Add(results);
        }
        return result;
    }

    public static void Print(List<int> collection, Action<List<int>> myAct)
    {
        myAct(collection);
    }
}