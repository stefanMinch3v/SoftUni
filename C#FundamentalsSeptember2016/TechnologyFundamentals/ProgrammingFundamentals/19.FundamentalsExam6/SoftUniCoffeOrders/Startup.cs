using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        List<decimal> totalResult = new List<decimal>();
        for (int i = 0; i < input; i++)
        {
            decimal sum = 0;
            decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
            string[] currentDate = Console.ReadLine().Split('/');
            int month = int.Parse(currentDate[1]);
            int year = int.Parse(currentDate[2]);
            int date = DateTime.DaysInMonth(year, month);
            long capsulesCount = long.Parse(Console.ReadLine());
            sum = (date * capsulesCount) * pricePerCapsule;
            Console.WriteLine($"The price for the coffee is: ${sum:f2}");
            totalResult.Add(sum);
        }
        Console.WriteLine($"Total: ${totalResult.Sum():f2}");
    }
}
