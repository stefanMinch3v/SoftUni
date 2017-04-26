using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExerciseParentheses
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();

        if (input.Length % 2 == 0)
        {
            char[] elements = input.ToCharArray();
            Stack<char> first = new Stack<char>();
            Queue<char> second = new Queue<char>();
            int counter = elements.Length / 2;
            int halfElements = elements.Length / 2;

            for (int i = 0; i < halfElements; i++)
            {
                first.Push(elements[i]);
            }

            for (int i = halfElements; i < elements.Length; i++)
            {
                second.Enqueue(elements[i]);
            }

            for (int i = 0; i < halfElements; i++)
            {
                char firstSymbol = first.Pop();
                char secondSymbol = second.Dequeue();
                if ((firstSymbol == '(' && secondSymbol == ')')
                        || (firstSymbol == '{' && secondSymbol == '}')
                        || (firstSymbol == '[' && secondSymbol == ']'))
                {
                    counter--;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
        else
        {
            Console.WriteLine("NO");
        }


        //second way
        //string input = Console.ReadLine();

        //Stack<char> stack = new Stack<char>();

        //for (int i = 0; i < input.Length; i++)
        //{
        //    char parentheses = input[i];

        //    switch (parentheses)
        //    {
        //        case '{':
        //            stack.Push('{');
        //            break;
        //        case '[':
        //            stack.Push('[');
        //            break;
        //        case '(':
        //            stack.Push('(');
        //            break;
        //        case '}':
        //            if (stack.Count > 0)
        //            {
        //                char currentElement = stack.Pop();
        //                if (currentElement != '{')
        //                {
        //                    Console.WriteLine("NO");
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("NO");
        //                return;
        //            }
        //            break;
        //        case ']':
        //            if (stack.Count > 0)
        //            {
        //                char currentElement = stack.Pop();
        //                if (currentElement != '[')
        //                {
        //                    Console.WriteLine("NO");
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("NO");
        //                return;
        //            }
        //            break;
        //        case ')':
        //            if (stack.Count > 0)
        //            {
        //                char currentElement = stack.Pop();
        //                if (currentElement != '(')
        //                {
        //                    Console.WriteLine("NO");
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("NO");
        //                return;
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //if (stack.Count == 0)
        //{
        //    Console.WriteLine("YES");
        //}
        //else
        //{
        //    Console.WriteLine("NO");
        //}
    }
}
