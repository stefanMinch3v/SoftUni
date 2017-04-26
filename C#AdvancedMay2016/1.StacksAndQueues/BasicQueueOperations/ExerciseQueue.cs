using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExerciseQueue
{
    public static void Main(string[] args)
    {
        Queue<int> numbers = new Queue<int>();
        int[] inputChecks = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int pushLimit = inputChecks[0];
        int popLimit = inputChecks[1];
        int checkNumber = inputChecks[2];

        for (int i = 0; i < pushLimit; i++)
        {
            numbers.Enqueue(inputNumbers[i]);
        }

        for (int i = 0; i < popLimit; i++)
        {
            numbers.Dequeue();
        }

        if (numbers.Contains(checkNumber))
        {
            Console.WriteLine("true");
        }
        else
        {
            if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                int min = Int32.MaxValue;
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers.Dequeue() < min)
                    {
                        min = numbers.Dequeue();
                    }
                }
                Console.WriteLine(min);
            }
        }
    }
}
