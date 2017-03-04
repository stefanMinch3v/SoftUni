using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableMarket
{
    class VegetableMarket
    {
        static void Main(string[] args)
        {
            Console.Write("Price for 1kg vegetables : ");
            var vegetable = double.Parse(Console.ReadLine());
            Console.Write("Price for 1kg fruit : ");
            var fruit = double.Parse(Console.ReadLine());
            Console.Write("How many kg for vegetables : ");
            var kg = int.Parse(Console.ReadLine());
            Console.Write("How many kg for fruit : ");
            var kg2 = int.Parse(Console.ReadLine());
            double result = (vegetable * kg + fruit * kg) / 1.94f;
            Console.WriteLine("All together are : " + result + " Euro");

        }
    }
}
