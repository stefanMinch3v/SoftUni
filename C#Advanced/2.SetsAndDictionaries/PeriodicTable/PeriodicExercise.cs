using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PeriodicExercise
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        SortedSet<string> compounds = new SortedSet<string>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();

            foreach (var entry in input)
            {
                compounds.Add(entry);
            }
        }

        Console.WriteLine(string.Join(" ", compounds));
    }
}
