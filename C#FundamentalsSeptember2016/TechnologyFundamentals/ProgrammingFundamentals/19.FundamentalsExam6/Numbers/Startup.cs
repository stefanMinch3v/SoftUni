using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        long[] numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();
        double average = numbers.Average();
        var greaterNumbers = numbers
                                    .Where(x => x > average)
                                    .Select(x => x)
                                    .OrderByDescending(x => x)
                                    .ToArray();
        int counter = 0;
        if (greaterNumbers.Length > 1)
        {
            for (int i = 0; i < greaterNumbers.Length; i++)
            {
                if (greaterNumbers.Length <= 5)
                {
                    Console.Write(greaterNumbers[i] + " ");
                }
                else
                {
                    while (counter != 5)
                    {
                        Console.Write(greaterNumbers[i] + " ");
                        counter++;
                        i++;
                    }
                }
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No");
        }


    }
}
