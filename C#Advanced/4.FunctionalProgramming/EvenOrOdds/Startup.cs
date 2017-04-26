using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int start = input[0];
        int end = input[1];

        string command = Console.ReadLine();

        List<int> result = new List<int>();
        switch (command)
        {
            case "even":
                result = Predicates.GetEvens(start, end);
                Predicates.Print(result, x => Console.WriteLine(string.Join(" ", x)));
                break;
            case "odd":
                result = Predicates.GetOdds(start, end);
                Predicates.Print(result, x => Console.WriteLine(string.Join(" ", x)));
                break;
            default:
                break;
        }
    }
}

public static class Predicates
{
    public static List<int> GetEvens(int start, int end)
    {
        List<int> even = new List<int>();
        for (int i = start; i <= end; i++)
        {
            if (i % 2 == 0)
            {
                even.Add(i);
            }
        }
        return even;
    }

    public static void Print(List<int> collection, Action<List<int>> myAct)
    {
        myAct(collection);
    }

    public static List<int> GetOdds(int start, int end)
    {
        List<int> odd = new List<int>();
        for (int i = start; i <= end; i++)
        {
            if (i % 2 == 1 || i % 2 == -1)
            {
                odd.Add(i);
            }
        }
        return odd;
    }
}   