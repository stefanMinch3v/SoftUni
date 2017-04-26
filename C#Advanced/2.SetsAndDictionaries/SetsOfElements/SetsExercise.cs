using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SetsExercise
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        HashSet<int> firstSet = new HashSet<int>();
        HashSet<int> secondSet = new HashSet<int>();

        int first = input[0];
        int second = input[1];

        for (int i = 0; i < first; i++)
        {
            firstSet.Add(int.Parse(Console.ReadLine()));
        }
        for (int i = 0; i < second; i++)
        {
            secondSet.Add(int.Parse(Console.ReadLine()));
        }

        foreach (var number in firstSet)
        {
            if (secondSet.Contains(number))
            {
                Console.Write(number + " ");
            }
        }
        Console.WriteLine();
    }
}
