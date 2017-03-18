using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Roli_The_Coder
{
    public static void Main(string[] args)
    {
        string checkingPattern = @"#([a-zA-Z0-9@]+)";
        Regex checkKey = new Regex(checkingPattern);

        string checkingPattern2 = @"([0-9]+\s+#)";
        Regex checkKey2 = new Regex(checkingPattern2);

        string pattern = @"([a-zA-Z0-9@]+)";
        Regex regexKey = new Regex(pattern);
        
        Dictionary<int, SortedDictionary<string, List<string>>> events = new Dictionary<int, SortedDictionary<string, List<string>>>();

        string input = Console.ReadLine();

        while (! input.Equals("Time for Code"))
        {
            if (! checkKey.IsMatch(input)  || ! checkKey2.IsMatch(input))
            {
                goto lastLine;
            }

            MatchCollection collection = regexKey.Matches(input);
            int id = 0;
            string eventName = string.Empty;
            List<string> participants = new List<string>();

            id = int.Parse(collection[0].Groups[0].ToString());
            eventName = collection[1].Groups[0].ToString();

            for (int i = 2; i < collection.Count; i++)
            {
                participants.Add(collection[i].Groups[0].ToString());
            }

            FillOutDictionary(events, id, eventName, participants);

            lastLine: input = Console.ReadLine();
        }

        PrintOutInfo(events);
        
    }

    private static void PrintOutInfo(Dictionary<int, SortedDictionary<string, List<string>>> events)
    {
        var finalResult = events.OrderByDescending(a => a.Value.Values.Sum(p => p.Count));
        foreach (var item in finalResult)
        {
            foreach (var data1 in item.Value)
            {
                Console.WriteLine($"{data1.Key} - {data1.Value.Distinct().Count()}");
            }
            foreach (var data in item.Value.Values)
            {
                foreach (var save in data.Distinct().OrderBy(n => n))
                {
                    Console.WriteLine(save);
                }
            }
        }
    }

    private static void FillOutDictionary(Dictionary<int, SortedDictionary<string, List<string>>> events, int id, string eventName, List<string> participants)
    {
        if (! events.ContainsKey(id))
        {
            events.Add(id, new SortedDictionary<string,  List<string>>());
            events[id].Add(eventName, new List<string>());
            events[id][eventName].AddRange(participants);
        }
        else
        {
            if (events[id].ContainsKey(eventName))
            {
                events[id][eventName].AddRange(participants);
            }
        }
        
    }
}
