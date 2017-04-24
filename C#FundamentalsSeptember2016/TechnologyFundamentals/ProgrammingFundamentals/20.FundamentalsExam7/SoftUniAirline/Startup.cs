using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        int numOfFlights = int.Parse(Console.ReadLine());
        List<string> allFlights = new List<string>();
        List<decimal> overallProfit = new List<decimal>();

        for (int i = 0; i < numOfFlights; i++)
        {
            long adultCount = long.Parse(Console.ReadLine());
            decimal adultPrice = decimal.Parse(Console.ReadLine());
            long youngCount = long.Parse(Console.ReadLine());
            decimal youngPrice = decimal.Parse(Console.ReadLine());
            decimal fuelPrice = decimal.Parse(Console.ReadLine());
            decimal fuelConsumption = decimal.Parse(Console.ReadLine());
            int flightDuration = int.Parse(Console.ReadLine());
            decimal income = (adultCount * adultPrice) + (youngCount * youngPrice);
            decimal expenses = fuelPrice * fuelConsumption * flightDuration;
            decimal result = income - expenses;
            overallProfit.Add(result);

            if (income >= expenses)
            {
                allFlights.Add($"You are ahead with {result:f3}$.");
            }
            else
            {
                allFlights.Add($"We've got to sell more tickets! We've lost {result:f3}$.");
            }
        }
        decimal overall = overallProfit.Sum();
        decimal average = overallProfit.Average();

        foreach (var item in allFlights)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"Overall profit -> {overall:f3}$.");
        Console.WriteLine($"Average profit -> {average:f3}$.");
    }
}
