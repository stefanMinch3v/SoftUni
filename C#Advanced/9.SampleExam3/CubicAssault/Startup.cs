using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<Legion> legions = new List<Legion>();

        while (input != "Count em all")
        {
            string[] commandLine = input.Split(new string[] {"->"}, StringSplitOptions.None);
            string region = commandLine[0].Trim();
            string meteor = commandLine[1].Trim();
            long count = long.Parse(commandLine[2].Trim());

            FilloutDictionary(legions, region, meteor, count);

            input = Console.ReadLine();
        }
        PrintoutResults(legions);
    }

    private static void PrintoutResults(List<Legion> legions)
    {
        foreach (var item in legions
                                    .OrderByDescending(x => x.meteors["Black"])
                                    .ThenBy(x => x.Region.Length)
                                    .ThenBy(x => x.Region))
        {
            Console.WriteLine(item.Region);
            foreach (var leg in item.meteors
                                        .OrderByDescending(x => x.Value)
                                        .ThenBy(x => x.Key))
            {
                Console.WriteLine($"-> {leg.Key} : {leg.Value}");
            }
        }
    }

    private static void FilloutDictionary(List<Legion> legions, string region, string meteor, long count)
    {
        if (!legions.Any(x => x.Region.Equals(region)))
        {
            Legion legion = new Legion(region);

            legion.meteors.Add("Black", 0);
            legion.meteors.Add("Red", 0);
            legion.meteors.Add("Green", 0);

            if (legion.meteors.ContainsKey(meteor))
            {
                legion.meteors[meteor] += count;
                if (legion.meteors["Green"] >= 1000000)
                {
                    while (legion.meteors["Green"] >= 1000000)
                    {
                        legion.meteors["Red"] += 1;
                        legion.meteors["Green"] -= 1000000;
                    }
                }
                if (legion.meteors["Red"] >= 1000000)
                {
                    while (legion.meteors["Red"] >= 1000000)
                    {
                        legion.meteors["Black"] += 1;
                        legion.meteors["Red"] -= 1000000;
                    }
                }
            }

            legions.Add(legion);
        }
        else
        {
            Legion legion = legions.First(x => x.Region.Equals(region));
            legion.meteors[meteor] += count;
            if (legion.meteors["Green"] >= 1000000)
            {
                while (legion.meteors["Green"] >= 1000000)
                {
                    legion.meteors["Red"] += 1;
                    legion.meteors["Green"] -= 1000000;
                }
            }
            if (legion.meteors["Red"] >= 1000000)
            {
                while (legion.meteors["Red"] >= 1000000)
                {
                    legion.meteors["Black"] += 1;
                    legion.meteors["Red"] -= 1000000;
                }
            }
        }
    }
}

class Legion
{
    public string Region { get; set; }

    public Dictionary<string, long> meteors { get; set; }

    public Legion(string region)
    {
        this.Region = region;
        meteors = new Dictionary<string, long>();
    }

    public Dictionary<string, long> GetAll()
    {
        return meteors;
    }
}
