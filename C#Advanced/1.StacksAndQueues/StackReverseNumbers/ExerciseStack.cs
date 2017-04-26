using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExerciseStack
{
    public static void Main()
    {
        int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Stack<int> numbers = new Stack<int>();
        foreach (var num in input)
        {
            numbers.Push(num);
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}
