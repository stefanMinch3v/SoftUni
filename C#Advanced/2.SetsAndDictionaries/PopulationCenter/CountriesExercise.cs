using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CountriesExercise
{
    public static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, long>> populationCenter = new Dictionary<string, Dictionary<string, long>>();
        string input = Console.ReadLine();

        while (!input.Equals("report"))
        {
            string[] command = input.Split(new char[] { '|' }).ToArray();
            string city = command[0];
            string country = command[1];
            long population = long.Parse(command[2]);

            FillOutPopulationCenter(populationCenter, country, city, population);

            input = Console.ReadLine();
        }

        foreach (var kvp in populationCenter.OrderByDescending(totalPop => totalPop.Value.Values.Sum()))
        { 
            var country = kvp.Key;
            var totalPopulaton = kvp.Value.Values.Sum();
            
            Console.WriteLine($"{country} (total population: {totalPopulaton})");

            foreach (var secondKvp in kvp.Value.OrderByDescending(p => p.Value))
            {
                var city = secondKvp.Key;
                var population = secondKvp.Value;
                Console.WriteLine($"=>{city}: {population}");
            }
        }
        
    }

    private static void FillOutPopulationCenter(Dictionary<string, Dictionary<string, long>> populationCenter, string country, string city, long population)
    {
        if (!populationCenter.ContainsKey(country))
        {
            populationCenter.Add(country, new Dictionary<string, long>());
            populationCenter[country].Add(city, population);
        }
        else
        {
            if (!populationCenter[country].ContainsKey(city))
            {
                populationCenter[country].Add(city, population);
            }
            else
            {
                populationCenter[country][city] += population;
            }
        }
    }
}
