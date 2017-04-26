using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Func<int[], int> myFunc = GetSmallestNumber;
        int result = myFunc(numbers);
        Console.WriteLine(result);
        
    }

    private static int GetSmallestNumber(int[] numbers)
    {
        return numbers.Min();
    }
}
