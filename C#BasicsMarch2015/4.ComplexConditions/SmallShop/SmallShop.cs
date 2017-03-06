using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop
{
    class SmallShop
    {
        static void Main(string[] args)
        {
            Console.Write("Choose city(Sofia,Plovdiv,Varna): ");
            var city = Console.ReadLine().ToLower();
            Console.Write("Choose product(coffee,water,beer,sweets,peanuts): ");
            var product = Console.ReadLine().ToLower();
            Console.Write("Choose quantity: ");
            var quantity = double.Parse(Console.ReadLine());
            if(city == "sofia")
            {
                if(product == "coffee")
                {
                    Console.WriteLine(0.50 * quantity);
                }
                if (product == "water")
                {
                    Console.WriteLine(0.80 * quantity);
                }
                if (product == "beer")
                {
                    Console.WriteLine(1.20 * quantity);
                }
                if (product == "sweets")
                {
                    Console.WriteLine(1.45 * quantity);
                }
                if (product == "peanuts")
                {
                    Console.WriteLine(1.60 * quantity);
                }
            }

            if (city == "varna")
            {
                if (product == "coffee")
                {
                    Console.WriteLine(0.45 * quantity);
                }
                if (product == "water")
                {
                    Console.WriteLine(0.70 * quantity);
                }
                if (product == "beer")
                {
                    Console.WriteLine(1.10 * quantity);
                }
                if (product == "sweets")
                {
                    Console.WriteLine(1.35 * quantity);
                }
                if (product == "peanuts")
                {
                    Console.WriteLine(1.55 * quantity);
                }
            }

            if (city == "plovdiv")
            {
                if (product == "coffee")
                {
                    Console.WriteLine(0.40 * quantity);
                }
                if (product == "water")
                {
                    Console.WriteLine(0.70 * quantity);
                }
                if (product == "beer")
                {
                    Console.WriteLine(1.15 * quantity);
                }
                if (product == "sweets")
                {
                    Console.WriteLine(1.30 * quantity);
                }
                if (product == "peanuts")
                {
                    Console.WriteLine(1.50 * quantity);
                }
            }
        }
    }
}
