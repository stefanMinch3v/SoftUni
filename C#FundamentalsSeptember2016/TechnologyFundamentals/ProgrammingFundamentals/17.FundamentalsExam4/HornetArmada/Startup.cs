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
        Dictionary<string, int> activityArmada = new Dictionary<string, int>();
        Dictionary<string, Dictionary<string, long>> hornetArmada = new Dictionary<string, Dictionary<string, long>>();

        int rows = int.Parse(Console.ReadLine());
        for (int i = 0; i < rows; i++)
        {
            string[] input = Console.ReadLine().Split(new string[] { "=", "->", ":" }, StringSplitOptions.None);
            int activity = int.Parse(input[0].Trim());
            string legionName = input[1].Trim();
            string soldierType = input[2].Trim();
            long countSoldier = long.Parse(input[3].Trim());

            FilloutDictionaries(activityArmada, hornetArmada, activity, legionName, soldierType, countSoldier);
        }

        string delimiter = Console.ReadLine();

        if (delimiter.Contains("\\"))
        {
            //invokes the nested dictionary
            string[] twoDelimiters = delimiter.Split('\\');
            int numberActivity = int.Parse(twoDelimiters[0]);
            string searchSolderType = twoDelimiters[1];
            PrintoutResult(numberActivity, searchSolderType, activityArmada, hornetArmada);
        }
        else
        {
            //invokes the simple dictionary
            string searchSoldierType = delimiter;
            PrintoutResult2(activityArmada, hornetArmada, searchSoldierType);
        }
    }

    private static void PrintoutResult2(Dictionary<string, int> activityArmada, Dictionary<string, Dictionary<string, long>> hornetArmada, string searchSoldierType)
    {
        //var neededSoldier = hornetArmada.Where(x => x.Value.Keys.Contains(searchSoldierType)).Select(x => x.Key).ToList();
        //foreach (var kvp in activityArmada.OrderByDescending(x => x.Value))
        //{
        //    if (neededSoldier.Any(x => x == kvp.Key))
        //    {
        //        Console.WriteLine($"{kvp.Value} : {kvp.Key}");
        //    }
        //}

        foreach (var legion in activityArmada.OrderByDescending(x => x.Value))
        {
            if (hornetArmada[legion.Key].ContainsKey(searchSoldierType))
            {
                Console.WriteLine("{0} : {1}", legion.Value, legion.Key);
            }
        }
    }

    private static void PrintoutResult(int numberActivity, string searchSolderType, Dictionary<string, int> activityArmada, Dictionary<string, Dictionary<string, long>> hornetArmada)
    {
        //var underActivity = activityArmada.Where(x => x.Value < numberActivity).Select(x => x.Key).ToList();

        //foreach (var kvp in hornetArmada.OrderByDescending(x => x.Value.Values.Sum()))
        //{
        //    foreach (var secondDic in kvp.Value)
        //    {
        //        if (underActivity.Any(x => x == kvp.Key) && secondDic.Key == searchSolderType)
        //        {
        //            Console.WriteLine($"{kvp.Key} -> {secondDic.Value}");
        //        }
        //    }    
        //}

        foreach (var kvp in hornetArmada
                                        .Where(x => x.Value.ContainsKey(searchSolderType))
                                        .OrderByDescending(x => x.Value[searchSolderType]))
        {
            if (activityArmada[kvp.Key] < numberActivity)
            {
                Console.WriteLine("{0} -> {1}", kvp.Key, hornetArmada[kvp.Key][searchSolderType]);
            }
        }

        
    }

    private static void FilloutDictionaries(Dictionary<string, int> activityArmada, Dictionary<string, Dictionary<string, long>> hornetArmada, int activity, string legionName, string soldierType, long countSoldier)
    {
        if (!activityArmada.ContainsKey(legionName))
        {
            activityArmada.Add(legionName, activity);
        }
        else
        {
            if (activityArmada[legionName] < activity)
            {
                activityArmada[legionName] = activity;
            }
        }

        if (!hornetArmada.ContainsKey(legionName))
        {
            hornetArmada.Add(legionName, new Dictionary<string, long>());
            hornetArmada[legionName].Add(soldierType, countSoldier);
        }
        else
        {
            if (!hornetArmada[legionName].ContainsKey(soldierType))
            {
                hornetArmada[legionName].Add(soldierType, countSoldier);
            }
            else
            {
                hornetArmada[legionName][soldierType] += countSoldier;
            }
        }
    }
}
