using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StackExercise
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Stack<int> elements = new Stack<int>();
        Stack<int> maxElements = new Stack<int>();
        int maxElement = Int32.MinValue;

        if (n >= 1)
        {
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int command = input[0];

                switch (command)
                {
                    case 1:
                        int pushNumber = input[1];
                        elements.Push(pushNumber);

                        if (maxElements.Count == 0 || pushNumber >= maxElements.Peek())
                        {
                            maxElements.Push(pushNumber);
                        }
                        break;
                    case 2:
                        int topElement = elements.Pop();
                        int currentMaxElement = maxElements.Peek();
                        if (topElement == currentMaxElement)
                        {
                            maxElements.Pop();
                        }
                        break;
                    case 3:
                        Console.WriteLine(maxElements.Peek());
                        break;
                }
            }
        }
    }
}
