using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReport
{
    class SalesReport
    {
        public static void Main(string[] args)
        {

            Sale[] sales = ReadSales();

            //solution 1
            /*string[] city = sales.Select(c => c.City).Distinct().OrderBy(a => a).ToArray();

            foreach (string town in city)
            {
                decimal salesByCity = sales.Where(c => c.City == town).Select(s => s.Price * s.Quantity).Sum();
                Console.WriteLine("{0} -> {1:f2}", town, salesByCity);
            }
            */

            //solution 2 much easier and faster 
            SortedDictionary<string, decimal> salesByTown = new SortedDictionary<string, decimal>();
            foreach (var item in sales)
            {
                var towns = item.City;
                var price = item.Price;
                var quantity = item.Quantity;
                AddItemsToDictionary(salesByTown, towns, price, quantity);
            }
            
            SumAllTownsResults(salesByTown);
        }

        private static void SumAllTownsResults(SortedDictionary<string, decimal> salesByTown)
        {
            foreach (var result in salesByTown)
            {
                string city = result.Key;
                decimal price = result.Value;

                Console.WriteLine("{0} -> {1:f2}", city, price);
            }
        }

        private static void AddItemsToDictionary(SortedDictionary<string, decimal> salesByTown, string towns, decimal price, decimal quantity)
        {
            if (!salesByTown.ContainsKey(towns))
            {
                salesByTown.Add(towns, 0);
            }
            salesByTown[towns] += price * quantity;
        }

        static Sale[] ReadSales()
        {
            int n = int.Parse(Console.ReadLine());
            Sale[] sales = new Sale[n];
            for (int i = 0; i < n; i++)
            {
                sales[i] = ReadSale();
            }
            return sales;
        }

        static Sale ReadSale()
        {
            string[] command = Console.ReadLine().Split().ToArray();
            return new Sale()
            {
                City = command[0],
                Product = command[1],
                Price = decimal.Parse(command[2]),
                Quantity = decimal.Parse(command[3]),
            };
        }
    }
    class Sale
    {
        public string City { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
