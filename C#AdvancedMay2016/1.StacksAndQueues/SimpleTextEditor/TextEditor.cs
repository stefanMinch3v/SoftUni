using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TextEditor
{
    public static void Main(string[] args)
    {
        //TODO
        int num = int.Parse(Console.ReadLine());
        Queue<string> text = new Queue<string>();
        Queue<string> undo = new Queue<string>();

        for (int i = 0; i < num; i++)
        {
            string[] input = Console.ReadLine().Split();
            int command = int.Parse(input[0]);
            string elements = input[1];

            switch (command)
            {
                case 1:
                    for (int e = 0; e < elements.Length; e++)
                    {
                        text.Enqueue(elements.Substring(e, 1));
                    }
                    break;
                case 2:
                    

                    break;
                case 3:
                    int index = int.Parse(elements);
                    Queue<string> keepElements = new Queue<string>();

                    for (int j = 0; j < index; j++)
                    {
                        if (text.Count == 1)
                        {
                            Console.WriteLine(text.Peek());
                        }
                        keepElements.Enqueue(text.Dequeue());
                    }

                    for (int e = 0; e < keepElements.Count; e++)
                    {
                        text.Enqueue(keepElements.Dequeue());
                    }
                    break;
                case 4:

                    break;
                default:
                    break;
            }
        }
        Console.WriteLine();
    }
}
