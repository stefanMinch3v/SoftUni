using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        Dictionary<string, string> consumersCoffee = new Dictionary<string, string>();
        Dictionary<string, int> coffeeType = new Dictionary<string, int>();

        string[] delimiters = Console.ReadLine().Split();
        string person = delimiters[0];
        string coffee = delimiters[1];
        string input = Console.ReadLine();

        while (input != "end of info")
        {
            if (input.Contains(person))
            {
                string[] commandLine = input.Split(new string[] { person }, StringSplitOptions.None);
                string firstName = commandLine[0];
                string coffeeName = commandLine[1];
                FilloutFirstDictionary(consumersCoffee, coffeeType ,firstName, coffeeName);
            }
            else if (input.Contains(coffee))
            {
                string[] commandLine = input.Split(new string[] { coffee }, StringSplitOptions.None);
                string coffeeName = commandLine[0];
                int quantity = int.Parse(commandLine[1]);
                FilloutSecondDictionary(coffeeType, coffeeName, quantity);
            }

            input = Console.ReadLine();
        }
        PrintOutOfCoffe(coffeeType);

        input = Console.ReadLine();
        while (input != "end of week")
        {
            string[] commandLine = input.Split();
            string username = commandLine[0];
            int numOfCoffee = int.Parse(commandLine[1]);
            FilloutLastDic(consumersCoffee, coffeeType, username, numOfCoffee);

            input = Console.ReadLine();
        }
        PrintResult(consumersCoffee, coffeeType); 
    }

    private static void PrintOutOfCoffe(Dictionary<string, int> coffeeType)
    {
        string deleteKey = string.Empty;
        foreach (var kvp in coffeeType)
        {
            string key = kvp.Key;
            deleteKey = key;
            int value = kvp.Value;
            if (value <= 0)
            {
                Console.WriteLine($"Out of {key}");
            }
        }
        coffeeType.Remove(deleteKey);
    }

    private static void PrintResult(Dictionary<string, string> consumersCoffee, Dictionary<string, int> coffeeType)
    {
        foreach (var kvp in coffeeType)
        {
            string key = kvp.Key;
            int value = kvp.Value;
            if (value <= 0)
            {
                Console.WriteLine($"Out of {key}");
            }
        }

        Console.WriteLine("Coffee Left:");
        var orderedDict = coffeeType.OrderByDescending(v => v.Value)
            .ToDictionary(x => x.Key, x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);
        foreach (var kvp in orderedDict)
        {
            string key = kvp.Key;
            int value = kvp.Value;
            if (value > 0)
            {
                Console.WriteLine($"{key} {value}");
            }
        }

        Console.WriteLine("For:");
        var orderedDic = consumersCoffee.OrderBy(v => v.Value)
            .ThenByDescending(k => k.Key)
            .ToDictionary(x => x.Key, x => x.Value);
        foreach (var kvp in orderedDic)
        {
            string key = kvp.Key;
            string value = kvp.Value;

            foreach (var kvpCoffee in coffeeType)
            {
                string checkCoffe = kvpCoffee.Key;
                int checkQuantity = kvpCoffee.Value;

                if (value == checkCoffe)
                {
                    if (checkQuantity > 0)
                    {
                        Console.WriteLine($"{key} {value}");
                    }
                    
                }
            }
            
        }
    }

    private static void FilloutLastDic(Dictionary<string, string> consumersCoffee, Dictionary<string, int> coffeeType, string username, int numOfCoffee)
    {
        string name = string.Empty;
        string coffee = string.Empty;
        int sum = 0;
 
        foreach (var kvp in consumersCoffee)
        {
            string userN = kvp.Key;
            string coffeeN = kvp.Value;
            if (userN == username)
            {
                name = username;
                coffee = coffeeN;
            }
        }

        foreach (var kvp in coffeeType)
        {
            string kvpCoffee = kvp.Key;
            int quantity = kvp.Value;
            if (coffee == kvpCoffee)
            {
                sum = quantity - numOfCoffee;
            }
        }
        coffeeType[coffee] = sum;     
    }

    private static void FilloutSecondDictionary(Dictionary<string, int> coffeeType, string coffeeName, int quantity)
    {
        if (!coffeeType.ContainsKey(coffeeName))
        {
            coffeeType.Add(coffeeName, 0);
            coffeeType[coffeeName] += quantity;
        }
        else
        {
            coffeeType[coffeeName] += quantity;
        }
        
    }

    private static void FilloutFirstDictionary(Dictionary<string, string> consumersCoffee, Dictionary<string, int> coffeeType, string firstName, string coffeeName)
    {
        if (!consumersCoffee.ContainsKey(firstName))
        {
            consumersCoffee.Add(firstName, coffeeName);
        }

        if (!coffeeType.ContainsKey(coffeeName))
        {
            coffeeType.Add(coffeeName, 0);
        }
    }
}
