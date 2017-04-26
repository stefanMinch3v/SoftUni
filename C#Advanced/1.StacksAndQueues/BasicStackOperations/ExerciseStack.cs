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
        int numberOfElements = input[0];
        int numsToPop = input[1];
        int checkNumber = input[2];
        Stack<int> numbers = new Stack<int>();

        int[] elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        for (int i = 0; i < elements.Length; i++)
        {
            numbers.Push(elements[i]);
        }
 
        if (numbers.Count == numberOfElements)
        {
            for (int i = 0; i < numsToPop; i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(checkNumber))
            {
                Console.WriteLine("true");
            }
            else if(numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                int smallerNumber = Int32.MaxValue;
                foreach (var num in numbers)
                {
                    if (num < smallerNumber)
                    {
                        smallerNumber = num;
                    }
                }
                Console.WriteLine(smallerNumber);
            }
        }
    }
}
