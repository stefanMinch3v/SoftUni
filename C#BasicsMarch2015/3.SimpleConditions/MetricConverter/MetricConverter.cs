using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricConverter
{
    class MetricConverter
    {
        static void Main(string[] args)
        {
            Console.Write("Enter some number: ");
            var num = double.Parse(Console.ReadLine());
            Console.Write("Enter unit: ");
            var unit = Console.ReadLine();
            Console.Write("Convert unit to: ");
            var unitConv = Console.ReadLine();
            //convert all units to 1 meter
            if (unit == "km")
            {
                num = num / 0.001;
            }
            else if (unit == "mm")
            {
                num = num / 1000;
            }
            else if (unit == "cm")
            {
                num = num / 100;
            }
            else if (unit == "mi")
            {
                num = num / 0.000621371192;
            }
            else if (unit == "in")
            {
                num = num / 39.3700787;
            }
            else if (unit == "ft")
            {
                num = num / 3.2808399;
            }
            else if (unit == "yd")
            {
                num = num / 1.0936133;
            }

            if (unitConv == "km")
            {
                num = num * 0.001;
            }
            else if (unitConv == "mm")
            {
                num = num * 1000;
            }
            else if (unitConv == "cm")
            {
                num = num * 100;
            }
            else if (unitConv == "mi")
            {
                num = num * 0.000621371192;
            }
            else if (unitConv == "in")
            {
                num = num * 39.3700787;
            }
            else if (unitConv == "ft")
            {
                num = num * 3.2808399;
            }
            else if (unitConv == "yd")
            {
                num = num * 1.0936133;
            }
            Console.WriteLine(num);

        }
    }
}
