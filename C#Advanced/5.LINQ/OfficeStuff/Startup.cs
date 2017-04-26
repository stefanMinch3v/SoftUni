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
        int number = int.Parse(Console.ReadLine());
        Dictionary<string, Dictionary<string, int>> office = new Dictionary<string, Dictionary<string, int>>();

        for (int i = 0; i < number; i++)
        {
            string input = Console.ReadLine();

            List<string> items = Regex.Split(input, @"\W+").ToList();
            items.RemoveAt(items.Count - 1);
            items.RemoveAt(0);

            string company = items[0];
            string product = items[2];
            int amount = int.Parse(items[1]);

            FillOutOffice(office, company, product, amount);
        }

        foreach (var kvp in office.OrderBy(k => k.Key))
        {
            Console.Write($"{kvp.Key}: ");
            foreach (var product in kvp.Value)
            {
                if (product.Key == kvp.Value.Keys.Last())
                {
                    Console.Write($"{product.Key}-{product.Value}");
                }
                else
                {
                    Console.Write($"{product.Key}-{product.Value}, ");
                }
            }
            Console.WriteLine();
        }
    }

    private static void FillOutOffice(Dictionary<string, Dictionary<string, int>> office, string company, string product, int amount)
    {
        if (!office.ContainsKey(company))
        {
            office.Add(company, new Dictionary<string, int>());
        }
        if (!office[company].ContainsKey(product))
        {
            office[company].Add(product, 0);
        }
        office[company][product] += amount;
    }
}
