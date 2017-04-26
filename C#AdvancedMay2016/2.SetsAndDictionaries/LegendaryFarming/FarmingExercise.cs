using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FarmingExercise
{
    public static void Main(string[] args)
    {
        Dictionary<string, int> junkItems = new Dictionary<string, int>();
        Dictionary<string, int> legendaryItems = new Dictionary<string, int>();
        Dictionary<string, int> uniqueItems = new Dictionary<string, int>();

        legendaryItems.Add("shards", 250);     //•Shadowmourne
        legendaryItems.Add("fragments", 250);  //•Valanyr
        legendaryItems.Add("motes", 250);      //•Dragonwrath

        uniqueItems.Add("shards", 0);
        uniqueItems.Add("fragments", 0);
        uniqueItems.Add("motes", 0);

        List<string> input = Console.ReadLine().ToLower().Split().ToList();
        bool foundLegendary = false;

        while (!foundLegendary)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (i % 2 == 1)
                {
                    string item = input[i];
                    int value = int.Parse(input[i - 1]);
                    if (CheckItem(item))
                    {
                        uniqueItems[item] += value;
                        if (CheckUniqueItems(uniqueItems))
                        {
                            goto printData;
                        }
                    }
                    else
                    {
                        if (!junkItems.ContainsKey(item))
                        {
                            junkItems.Add(item, 0);
                        }
                        junkItems[item] += value;
                    }
                }   
            }
            

            input = Console.ReadLine().ToLower().Split().ToList();
        }

        printData:
        PrintOutAllData(legendaryItems, junkItems, uniqueItems);
    }

    private static bool CheckUniqueItems(Dictionary<string, int> uniqueItems)
    {
        bool enoughPoints = false;
        foreach (var kvp in uniqueItems)
        {
            var value = kvp.Value;
            if (value >= 250)
            {
                enoughPoints =  true;
            }
        }
        return enoughPoints;
    }

    private static bool CheckItem(string item)
    {
        if (item == "shards" || item == "fragments" || item == "motes")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static void PrintOutAllData(Dictionary<string, int> legendaryItems, Dictionary<string, int> junkItems, Dictionary<string, int> uniqueItems)
    {
        int shards = 0;
        int fragments = 0;
        int motes = 0;
        foreach (var kvp in uniqueItems)
        {
            var key = kvp.Key;
            if (key == "shards")
            {
                shards = uniqueItems[key];
            }
            else if (key == "fragments")
            {
                fragments = uniqueItems[key];
            }
            else
            {
                motes = uniqueItems[key];
            }
        }

        foreach (var kvp in legendaryItems)
        {
            string legendaryItem = kvp.Key;
            int legendaryValue = kvp.Value;

            foreach (var item in uniqueItems)
            {
                string itemKey = item.Key;
                int itemValue = item.Value;

                if (legendaryItem == itemKey && itemValue >= legendaryValue)
                {
                    switch (itemKey)
                    {
                        case "shards":
                            shards = Math.Abs(itemValue - legendaryValue);
                            Console.WriteLine("Shadowmourne obtained!");
                            break;
                        case "fragments":
                            fragments = Math.Abs(itemValue - legendaryValue);
                            Console.WriteLine("Valanyr obtained!");
                            break;
                        case "motes":
                            motes = Math.Abs(itemValue - legendaryValue);
                            Console.WriteLine("Dragonwrath obtained!");
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        if (uniqueItems.ContainsKey("shards"))
        {
            uniqueItems["shards"] = shards;
        }
        if (uniqueItems.ContainsKey("fragments"))
        {
            uniqueItems["fragments"] = fragments;
        }
        if (uniqueItems.ContainsKey("motes"))
        {
            uniqueItems["motes"] = motes;
        }

        foreach (var kvp in uniqueItems.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
        {
            var key = kvp.Key;
            var value = kvp.Value;
            Console.WriteLine($"{key}: {value}");
        }
        

        foreach (var kvp in junkItems.OrderBy(k => k.Key))
        {
            var key = kvp.Key;
            var value = kvp.Value;
            Console.WriteLine($"{key}: {value}");
        }
    }

}
