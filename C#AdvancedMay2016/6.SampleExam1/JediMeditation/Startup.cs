using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        Queue<string> masters = new Queue<string>();
        Queue<string> knights = new Queue<string>();
        Queue<string> padawans = new Queue<string>();
        Queue<string> specialJedi = new Queue<string>();
        bool hasYoda = false;

        for (int i = 0; i < number; i++)
        {
            string[] input = Console.ReadLine().ToLower().Split();

            for (int j = 0; j < input.Length; j++)
            {
                char currentJedi = input[j][0];

                switch (currentJedi)
                {
                    case 'm':
                        masters.Enqueue(input[j]);
                        break;
                    case 'k':
                        knights.Enqueue(input[j]);
                        break;
                    case 'p':
                        padawans.Enqueue(input[j]);
                        break;
                    case 't':
                    case 's':
                        specialJedi.Enqueue(input[j]);
                        break;
                    case 'y':
                        hasYoda = true;
                        break;
                    default:
                        break;
                }
            }
        }
        if (hasYoda)
        {
            while (masters.Count != 0)
            {
                Console.Write(masters.Dequeue() + " ");
            }
            while (knights.Count != 0)
            {
                Console.Write(knights.Dequeue() + " ");
            }
            while (specialJedi.Count != 0)
            {
                Console.Write(specialJedi.Dequeue() + " ");
            }
            while (padawans.Count != 0)
            {
                Console.Write(padawans.Dequeue() + " ");
            }
        }
        else
        {
            while (specialJedi.Count != 0)
            {
                Console.Write(specialJedi.Dequeue() + " ");
            }
            while(masters.Count != 0)
            {
                Console.Write(masters.Dequeue() + " ");
            }
            while (knights.Count != 0)
            {
                Console.Write(knights.Dequeue() + " ");
            }
            while (padawans.Count != 0)
            {
                Console.Write(padawans.Dequeue() + " ");
            }
        }
        Console.WriteLine();

        //second way with StringBuilder, but put one empty space in the switch case each time after you add new jedi
        //StringBuilder finalResult = new StringBuilder();

        //if (hasYoda)
        //{   
        //    finalResult.Append(string.Join("", masters));
        //    finalResult.Append(string.Join("", knights));
        //    finalResult.Append(string.Join("", specialJedi));
        //    finalResult.Append(string.Join("", padawans));
        //    Console.WriteLine(finalResult.ToString().Trim());
        //}
        //else
        //{
        //    finalResult.Append(string.Join("", specialJedi));
        //    finalResult.Append(string.Join("", masters));
        //    finalResult.Append(string.Join("", knights));
        //    finalResult.Append(string.Join("", padawans));
        //    Console.WriteLine(finalResult.ToString().Trim());
        //}
    }
}
