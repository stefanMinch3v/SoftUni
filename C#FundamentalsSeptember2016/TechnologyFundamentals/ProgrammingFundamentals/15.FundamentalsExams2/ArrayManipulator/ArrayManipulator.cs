using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ArrayManipulator
{
    public static void Main(string[] args)
    {
        List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        string userInput = Console.ReadLine();

        while(! userInput.Equals("end"))
        {
            string[] command = userInput.Split();
            switch (command[0])
            {
                case "exchange":
                    input = ExchangeList(input, command);
                    break;
                case "max":
                    MaxEvenOrOdd(input, command);
                    break;
                case "min":
                    MinEvenOrOdd(input, command);
                    break;
                case "first":
                    FirstEvenOrOdd(input, command);
                    break;
                case "last":
                    LastEvenOrOdd(input, command);
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
            userInput = Console.ReadLine();
        }

        string final = string.Join(", ", input);
        Console.WriteLine($"[{final}]");
    }

    private static void LastEvenOrOdd(List<int> input, string[] command)
    {
        string evensOrOdds = command[2];
        if (evensOrOdds.Equals("odd"))
        {
            int choice = int.Parse(command[1]);
            if (choice > input.Count)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                List<int> lastOdd = new List<int>();
                List<string> parseOdd = new List<string>();

                for (int i = input.Count - 1; i >= 0; i--)
                {
                    if (input[i] % 2 != 0)
                    {
                        lastOdd.Add(input[i]);
                    }
                }
                if (lastOdd.Count < 1)
                {
                    parseOdd.Add("[]");
                    string result = string.Join("", parseOdd);
                    Console.WriteLine(result);
                }
                else
                {
                    int counter = 0;
                    for (int i = 0; i < choice; i++)
                    {
                        if (counter == lastOdd.Count)
                        {
                            break;
                        }
                        parseOdd.Add(lastOdd[i].ToString());/////////////////////////
                        counter++;
                    }

                    parseOdd.Reverse();
                    string result = string.Join(", ", parseOdd);
                    Console.WriteLine($"[{result}]");
                }
            }

        }
        else if (evensOrOdds.Equals("even"))
        {
            int choice = int.Parse(command[1]);
            if (choice > input.Count)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                List<int> lastEven = new List<int>();
                List<string> parseEven = new List<string>();

                for (int i = input.Count - 1; i >= 0; i--)
                {
                    if (input[i] % 2 == 0)
                    {
                        lastEven.Add(input[i]);
                    }
                }
                if (lastEven.Count < 1)
                {
                    parseEven.Add("[]");
                    string result = string.Join("", parseEven);
                    Console.WriteLine(result);
                }
                else
                {
                    int counter = 0;
                    for (int i = 0; i < choice; i++)
                    {
                        if (counter == lastEven.Count)
                        {
                            break;
                        }
                        parseEven.Add(lastEven[i].ToString());///////
                        counter++;
                    }
                    parseEven.Reverse();
                    string result = string.Join(", ", parseEven);
                    Console.WriteLine($"[{result}]");
                }
            }
        }
    }

    private static void FirstEvenOrOdd(List<int> input, string[] command)
    {
        string evenOrOdds = command[2];
        if (evenOrOdds.Equals("odd"))
        {
            int choice = int.Parse(command[1]);
            if (choice > input.Count)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                List<int> firstOdd = new List<int>();
                List<string> parseOdd = new List<string>();

                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] % 2 != 0)
                    {
                        firstOdd.Add(input[i]);
                    }
                }
                if (firstOdd.Count < 1 || choice < 0)
                {
                    parseOdd.Add("[]");
                    string result = string.Join("", parseOdd);
                    Console.WriteLine(result);
                }
                else
                {
                    int counter = 0;
                    for (int i = 0; i < firstOdd.Count; i++)
                    {
                        if (counter == choice)
                        {
                            break;
                        }
                        parseOdd.Add(firstOdd[i].ToString());////////
                        counter++;
                    }
                    string result = string.Join(", ", parseOdd);
                    Console.WriteLine($"[{result}]");
                }

            }

        }
        else if (evenOrOdds.Equals("even"))
        {
            int choice = int.Parse(command[1]);
            if (choice > input.Count)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                List<int> firstEven = new List<int>();
                List<string> parseEven = new List<string>();

                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] % 2 == 0)
                    {
                        firstEven.Add(input[i]);
                    }
                }

                if (firstEven.Count < 1 || choice < 0)
                {
                    parseEven.Add("[]");
                    string result = string.Join("", parseEven);
                    Console.WriteLine(result);
                }
                else
                {
                    int counter = 0;
                    for (int i = 0; i < firstEven.Count; i++)
                    {
                        if (counter == choice)
                        {
                            break;
                        }
                        parseEven.Add(firstEven[i].ToString());/////////
                        counter++;
                    }

                    string result = string.Join(", ", parseEven);
                    Console.WriteLine($"[{result}]");
                }
            }

        }
    }

    private static void MinEvenOrOdd(List<int> input, string[] command)
    {
        string evenOrOdd2 = command[1];
        if (evenOrOdd2.Equals("odd"))
        {
            int odd = int.MaxValue;
            int minIndex = -1;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] % 2 != 0)
                {
                    if (input[i] <= odd)
                    {
                        odd = input[i];
                        minIndex = i;
                    }
                }
            }
            if (minIndex == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int saveIndex = input.LastIndexOf(odd);
                Console.WriteLine(saveIndex);
            }
        }

        else if (evenOrOdd2.Equals("even"))
        {
            int even = int.MaxValue;
            int minIndex = - 1;
            int count = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] % 2 == 0)
                {
                    count = input[i];
                    if (count <= even)
                    {
                        even = count;
                        minIndex = i;
                    }
                }
            }
            if (minIndex == - 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int saveIndex = input.LastIndexOf(even);
                Console.WriteLine(saveIndex);
            }
        }
    }

    private static void MaxEvenOrOdd(List<int> input, string[] command)
    {
        string evenOrOdd = command[1];
        if (evenOrOdd.Equals("odd"))
        {
            int odd = 0;
            int count = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] % 2 != 0)
                {
                    count = input[i];
                    if (count >= odd)
                    {
                        odd = count;
                    }
                }
            }
            if (odd <= 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                string saveIndex = input.LastIndexOf(odd).ToString();//////////
                Console.WriteLine(saveIndex);
            }

        }
        else if (evenOrOdd.Equals("even"))
        {
            int even = 0;
            int count = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] % 2 == 0)
                {
                    count = input[i];
                    if (count >= even)
                    {
                        even = count;
                    }
                }
            }
            if (even <= 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                string saveIndex = input.LastIndexOf(even).ToString();
                Console.WriteLine(saveIndex);
            }
        }
    }

    private static List<int> ExchangeList(List<int> input, string[] command)
    {
        int index = int.Parse(command[1]);
 
        //index + 1 > input.Count || index < 0
        if (index < 0 || input.Count <= index)
        {
            Console.WriteLine("Invalid index");
            return input;
        }
        List<int> temp = input.Skip(index + 1).ToList();
        temp.AddRange(input.Take(index + 1));
        return temp;
    }
}

