using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        int divisable = int.Parse(Console.ReadLine());
        List<int> results = new List<int>();

        results = Functions.GetElements(numbers, x => x, divisable);
        Functions.Print(results, x => Console.WriteLine(string.Join(" ", x)));

    }
}

public class Functions
{
    public static List<int> GetElements(List<int> collection, Func<int, int> myFunc, int divisable)
    {
        List<int> result = new List<int>();
        foreach (var num in collection)
        {
            if (num % divisable != 0)
            {
                int number = myFunc(num);
                result.Add(number);
            }
        }
        result.Reverse();
        return result;
    }

    public static void Print(List<int> collection, Action<List<int>> myAct)
    {
        myAct(collection);
    }
 }
