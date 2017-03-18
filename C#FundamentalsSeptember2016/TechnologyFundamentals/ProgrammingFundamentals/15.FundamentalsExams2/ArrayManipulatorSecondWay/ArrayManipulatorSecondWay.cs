using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ArrayManipulatorSecondWay
{
    public static void Main()
    {
        List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        string command = Console.ReadLine().ToLower();

        while (!command.Equals("end"))
        {
            string[] userInput = command.Split(' ');

            switch (userInput[0])
            {
                case "exchange":
                    list = ExecuteExchange(list, userInput);
                    break;
                case "max":
                    GetMaxIndex(list, userInput);
                    break;
                case "min":
                    GetMinIndex(list, userInput);
                    break;
                case "first":
                    GetFirst(list, userInput);
                    break;
                case "last":
                    GetLast(list, userInput);
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }

            command = Console.ReadLine().ToLower();
        }

        Console.WriteLine($"[{string.Join(", ", list)}]");
    }

    private static void GetLast(List<int> list, string[] userInput)
    {
        int count = int.Parse(userInput[1]);

        if (count > list.Count())
        {
            Console.WriteLine("Invalid count");
            return;
        }

        string type = userInput[2];
        int remainder = type == "even" ? 0 : 1;

        List<int> temp = list.Where(x => x % 2 == remainder).Reverse().Take(count).Reverse().ToList();
        Console.WriteLine($"[{string.Join(", ", temp)}]");
    }

    private static void GetFirst(List<int> list, string[] userInput)
    {
        int count = int.Parse(userInput[1]);

        if (count > list.Count())
        {
            Console.WriteLine("Invalid count");
            return;
        }

        List<int> temp = new List<int>();

        string type = userInput[2];
        int remainder = type == "even" ? 0 : 1;


        for (int i = 0; i < list.Count(); i++)
        {
            if (list[i] % 2 == remainder && temp.Count() < count)
            {
                temp.Add(list[i]);
            }
        }

        Console.WriteLine($"[{string.Join(", ", temp)}]");
    }

    private static void GetMaxIndex(List<int> list, string[] userInput)
    {
        string type = userInput[1];
        int remainder = type == "even" ? 0 : 1;

        var filterd = list.Where(x => Math.Abs(x) % 2 == remainder);
        if (filterd.Count() > 0)
        {
            int max = filterd.Max();
            int maxIndex = list.LastIndexOf(max);
            Console.WriteLine(maxIndex);
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }

    private static void GetMinIndex(List<int> list, string[] userInput)
    {
        string type = userInput[1];
        int remainder = type == "even" ? 0 : 1;

        int minValue = int.MaxValue;
        int minIndex = -1;

        for (int i = 0; i < list.Count(); i++)
        {
            if (list[i] <= minValue && Math.Abs(list[i] % 2) == remainder)
            {
                minValue = list[i];
                minIndex = i;
            }
        }

        if (minIndex == -1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine(minIndex);
        }
    }

    private static List<int> ExecuteExchange(List<int> array, string[] userInput)
    {
        int index = int.Parse(userInput[1]);

        if (index < 0 || array.Count <= index)
        {
            Console.WriteLine("Invalid index");
            return array;
        }

        List<int> temp = array.Skip(index + 1).ToList();
        temp.AddRange(array.Take(index + 1));

        return temp;
    }
}

