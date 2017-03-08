using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
    public class PopulationCounter
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, int>> populationReport = new Dictionary<string, Dictionary<string, int>>();

            string consoleRead = Console.ReadLine();

            while (! consoleRead.Equals("report"))
            {
                string[] input = consoleRead.Split('|').ToArray();

                string country = input[1];
                string city = input[0];
                int population = int.Parse(input[2]);

                InsertGivenData(populationReport, country);
                InsertCityAndPopulation(populationReport, country, city, population);
                consoleRead = Console.ReadLine();
            }
            PrintOutTheGivenData(populationReport);
        }

        private static void InsertCityAndPopulation(Dictionary<string, Dictionary<string, int>> populationReport, string country, string city, int population)
        {
            if (! populationReport[country].ContainsKey(city))
            {
                populationReport[country].Add(city, 0);
            }
            populationReport[country][city] += population;
        }

        private static void PrintOutTheGivenData(Dictionary<string, Dictionary<string, int>> populationReport)
        {
            foreach (var item in populationReport.OrderByDescending(x => x.Value.Values.Max()))
            {
                if (item.Value.Values == item.Value.Values)
                {
                    populationReport.Where(a => a.Value.Values == a.Value.Values).OrderBy(b => b.Key);
                }
                int counter = populationReport.Where(a => a.Key.Equals("Bulgaria")).Sum(b => b.Value.Sum(c => c.Value));
                int counter2 = populationReport.Where(a => a.Key.Equals("Italy")).Sum(b => b.Value.Sum(c => c.Value));
                int counter3 = populationReport.Where(a => a.Key.Equals("UK")).Sum(b => b.Value.Sum(c => c.Value));

                if (item.Key.Equals("Bulgaria"))
                {
                    Console.Write("{0} (total population: {1})\n", item.Key, counter);
                }
                if (item.Key.Equals("Italy"))
                {
                    Console.Write("{0} (total population: {1})\n", item.Key, counter2);
                }
                if (item.Key.Equals("UK"))
                {
                    Console.Write("{0} (total population: {1})\n", item.Key, counter3);
                }

                foreach (var items in item.Value.OrderByDescending(i => i.Value))
                {
                    string city = items.Key;

                    Console.WriteLine("=>{1}: {0}", items.Value, city);
                }
               
            }
        }

        private static void InsertGivenData(Dictionary<string, Dictionary<string, int>> populationReport, string country)
        {
            if (! populationReport.ContainsKey(country))
            {
                populationReport.Add(country, new Dictionary<string, int>());
            }
        }
    }
}
