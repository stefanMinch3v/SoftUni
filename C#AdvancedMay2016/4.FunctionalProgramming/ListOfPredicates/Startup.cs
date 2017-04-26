using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        int[] divisors = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        List<int> numbers = new List<int>();
        for (int i = 1; i <= num; i++)
        {
            numbers.Add(i);
        }

        foreach (var divisor in divisors)
        {
            Predicates.AddPredicate(x => x % divisor == 0);
        }
        numbers = Predicates.ApplyPredicates(numbers);
        Console.WriteLine(string.Join(" ", numbers));
    }
}

public static class Predicates
{
    public static List<Func<int, bool>> predicates = new List<Func<int, bool>>();

    public static void AddPredicate(Func<int, bool> predicate)
    {
        predicates.Add(predicate);
    }

    public static List<int> ApplyPredicates(List<int> numbers)
    {
        List<int> result = new List<int>();
        bool legal = true;
        for (int i = 0; i < numbers.Count; i++)
        {
            int currentNum = numbers[i];
            foreach (var predicate in predicates)
            {
                if (!predicate(currentNum))
                {
                    legal = false;
                    break;
                }
            }
            if (legal)
            {
                result.Add(currentNum);
            }
            legal = true;
        }
        return result;
    }
}
