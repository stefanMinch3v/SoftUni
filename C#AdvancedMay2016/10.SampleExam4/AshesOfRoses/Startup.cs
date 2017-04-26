using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        Dictionary<string, Dictionary<string, long>> roses = new Dictionary<string, Dictionary<string, long>>();
        string input = Console.ReadLine();
        string pattern = @"^([Grow]+\s\<[A-Z]{1}[a-z]+\>\s\<[a-zA-Z0-9]+\>\s\d+)$";

        while (!input.Equals("Icarus, Ignite!"))
        {
            bool isValid = Regex.IsMatch(input, pattern);
            if (!isValid)
            {
                goto end;
            }

            string[] commandLine = input.Split(new char[] { ' ', '>', '<'}, StringSplitOptions.RemoveEmptyEntries);

            string grow = commandLine[0];
            string region = commandLine[1];
            string color = commandLine[2];
            long count = long.Parse(commandLine[3]);

            //bool validate = ValidateInput(grow, region, color, count);
            //if (!validate)
            //{
            //    input = Console.ReadLine();
            //    continue;
            //}

            FilloutDictionary(roses, region, color, count);


            end:  input = Console.ReadLine();
        }
        PrintDictionary(roses);
    }

    private static void PrintDictionary(Dictionary<string, Dictionary<string, long>> roses)
    {
        var orderedDict = roses.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key);
        foreach (var kvp in orderedDict)
        {
            Console.WriteLine(kvp.Key);
            foreach (var color in kvp.Value.OrderBy(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"*--{color.Key} | {color.Value}");
            }
        }
    }

    private static void FilloutDictionary(Dictionary<string, Dictionary<string, long>> roses, string region, string color, long count)
    {
        if (!roses.ContainsKey(region))
        {
            roses.Add(region, new Dictionary<string, long>());
            if (!roses[region].ContainsKey(color))
            {
                roses[region].Add(color, count);
            }
            else
            {
                roses[region][color] += count;
            }
        }
        else
        {
            if (!roses[region].ContainsKey(color))
            {
                roses[region].Add(color, count);
            }
            else
            {
                roses[region][color] += count;
            }
        }
    }

    private static bool ValidateInput(string grow, string region, string color, long count)
    {
        bool checkString = true;

        if (grow != "Grow")
        {
            checkString = false;
            goto end;
        }

        for (int i = 1; i < region.Length; i++)
        {
            if ( !(char.IsLetter(region[i]) && char.IsLower(region[i])) )
            {
                checkString = false;
                goto end;
            }
        }

        foreach (var item in color)
        {
            if (!char.IsLetterOrDigit(item))
            {
                checkString = false;
                break;
            }
        }

        end: return checkString;
    }
}
