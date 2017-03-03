using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelsiusToFahrenheit
{
    class CelsiusToFahrenheit
    {
        static void Main(string[] args)
        {
            Console.Write("Celsius = ");
            double celsius = double.Parse(Console.ReadLine());
            double convert = celsius * 9 / 5 + 32;
            Console.WriteLine("Fahrenheit = " + Math.Round(convert, 2));

        }
    }
}
