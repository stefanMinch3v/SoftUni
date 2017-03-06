using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Cinema
    {
        static void Main(string[] args)
        {
            Console.Write("Kind of project(Premiere, Normal or Discount): ");
            var project = Console.ReadLine().ToString();
            Console.Write("Enter rows: ");
            var row = double.Parse(Console.ReadLine());
            Console.Write("Enter columns: ");
            var column = double.Parse(Console.ReadLine());
            var price = -1.00;
            if (project == "premiere") price = 12.00;
            else if (project == "normal") price = 7.50;
            else if (project == "discount") price = 5.00;
            else Console.WriteLine("This kind of project is not available");
            if (price > 0) Console.WriteLine("Result of price for full hall is : {0:f2}", row * column * price);
        }
    }
}
