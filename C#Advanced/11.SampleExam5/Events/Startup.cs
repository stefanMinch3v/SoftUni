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
        List<Events> allEvents = new List<Events>();
        string pattern = @"^(\#([a-zA-Z:]+)[\s]{0,}([@a-zA-Z]+)[\s]{0,}([0-9]{2,2}:[0-9]{2,2}))$";
        int rows = int.Parse(Console.ReadLine());

        for (int i = 0; i < rows; i++)
        {
            string input = Console.ReadLine();
            bool isValid = Regex.IsMatch(input, pattern);
            if (!isValid)
            {
                continue;
            }

            Match takeEvents = Regex.Match(input, pattern);
            string name = takeEvents.Groups[2].Value.Substring(0, takeEvents.Groups[2].Value.Length - 1);
            string city = takeEvents.Groups[3].Value.Substring(1);

            string[] clock = takeEvents.Groups[4].Value.Split(':');
            int hours = int.Parse(clock[0]);
            int minutes = int.Parse(clock[1]);
            if (hours > 23)
            {
                continue;
            }
            string time = AdjustTheTime(hours, minutes);

            FilloutEvents(allEvents, city, name , time);
        }

        string[] locations = Console.ReadLine().Split(',');
        PrintResults(allEvents, locations);
    }

    private static void PrintResults(List<Events> allEvents, string[] locations)
    {
        foreach (var location in locations.OrderBy(x => x))
        {
            if (allEvents.Any(x => x.City == location))
            {
                foreach (var item in allEvents)
                {
                    if (item.City == location)
                    {
                        Console.WriteLine(item.City + ":");
                        int counter = 1;
                        foreach (var kvp in item.PersonTime.OrderBy(x => x.Key))
                        {  
                            Console.WriteLine($"{counter}. {kvp.Key} -> {string.Join(", ",kvp.Value.OrderBy(x => x))}");
                            counter++;
                        }
                    }                    
                }
            }
        }
    }

    private static void FilloutEvents(List<Events> allEvents, string city, string name, string time)
    {
        if (!allEvents.Any(x => x.City.Equals(city)))
        {
            Events events = new Events(city);
            events.PersonTime.Add(name, new List<string>());
            events.PersonTime[name].Add(time);
            allEvents.Add(events);
        }
        else
        {
            Events events = allEvents.First(x => x.City.Equals(city));
            if (!events.PersonTime.ContainsKey(name))
            {
                // events.PersonTime.Add(name, time);
                events.PersonTime.Add(name, new List<string>());

            }
            // events.PersonTime[name] += $"{time}";
            events.PersonTime[name].Add(time);
        }
    }

    private static string AdjustTheTime(int hours, int minutes)
    {
        while (minutes > 59)
        {
            hours++;
            minutes -= 60;
        }
        while (hours > 23)
        {
            hours -= 24;
        }

        string hoursAddZero = hours.ToString();
        string minutesAddZero = minutes.ToString();
        if (hoursAddZero.Length == 1)
        {
            hoursAddZero = "0" + hoursAddZero;
        }
        if (minutesAddZero.Length == 1)
        {
            minutesAddZero = "0" + minutesAddZero;
        }

        string result = $"{hoursAddZero}:{minutesAddZero}";
        return result;
    }
}

class Events
{
    public string City { get; set; }

    public Dictionary<string, List<string>> PersonTime { get; set; }

    public Events(string city)
    {
        this.City = city;
        PersonTime = new Dictionary<string, List<string>>();
    }
}
