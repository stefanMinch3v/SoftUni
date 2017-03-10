using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniCoffeeOrders
{
    public class SoftUniCoffeeOrders
    {
        public static void Main(string[] args)
        {
            decimal num = decimal.Parse(Console.ReadLine());
            List<decimal> saveResults = new List<decimal>();

            for (int i = 0; i < num; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                string[] dates = Console.ReadLine().Split('/');
                int month = int.Parse(dates[1]);
                int year = int.Parse(dates[2]);
                int parseDate = DateTime.DaysInMonth(year, month);
                decimal capsulesCount = decimal.Parse(Console.ReadLine());
                decimal finalResult = 0;
                finalResult = (parseDate * capsulesCount) * pricePerCapsule;
                saveResults.Add(finalResult);
            }

            foreach (var item in saveResults)
            {
                Console.WriteLine("The price for the coffee is: ${0:f2}", item);
            }

            Console.WriteLine("Total: ${0:f2}", saveResults.Sum());
        }
    }
}
