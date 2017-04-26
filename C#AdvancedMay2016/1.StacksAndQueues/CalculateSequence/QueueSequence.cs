using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class QueueSequence
{
    public static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());
        List<long> results = new List<long>();
        Queue<long> sequenceNumbers = new Queue<long>();
        sequenceNumbers.Enqueue(n);
        results.Add(n);

        while (results.Count < 50)
        {
            long currentElement = sequenceNumbers.Dequeue();

            long firstOperation = currentElement + 1;
            long secondOperation = (currentElement * 2) + 1;
            long thirdOperation = currentElement + 2;

            sequenceNumbers.Enqueue(firstOperation);
            sequenceNumbers.Enqueue(secondOperation);
            sequenceNumbers.Enqueue(thirdOperation);

            results.Add(firstOperation);
            results.Add(secondOperation);
            results.Add(thirdOperation);
        }

        for (int i = 0; i < 50; i++)
        {
            Console.Write(results[i] + " ");
        }
        Console.WriteLine();
    }
}
