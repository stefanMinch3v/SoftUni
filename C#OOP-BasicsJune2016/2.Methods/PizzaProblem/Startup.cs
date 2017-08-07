using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        MethodInfo[] methods = typeof(Pizza).GetMethods();
        bool containsMethod = methods.Any(m => m.ReturnType.Name.Contains("SortedDictionary"));
        if (!containsMethod)
        {
            throw new Exception();
        }

        string pattern = @"(\d+)(\w+)";
        string commandLine = Console.ReadLine();
        MatchCollection collection = Regex.Matches(commandLine, pattern);
        Pizza pizza = new Pizza();

        foreach (Match match in collection)
        {
            int number = int.Parse(match.Groups[1].ToString());
            string pizzaType = match.Groups[2].ToString();
            pizza.SetDictionary(number, pizzaType);
        }

        foreach (var item in pizza.GetDictionary)
        {
            int key = item.Key;
            string value = string.Join(", ", item.Value);
            Console.WriteLine($"{key} - {value}");
        }
    }
}
