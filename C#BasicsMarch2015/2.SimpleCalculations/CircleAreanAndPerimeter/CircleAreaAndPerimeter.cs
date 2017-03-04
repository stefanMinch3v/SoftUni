using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleAreanAndPerimeter
{
    class CircleAreaAndPerimeter
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a number to try : ");
            double r = double.Parse(Console.ReadLine());
            double area = Math.PI * r * r;
            double perimeter = 2 * Math.PI * r;
            Console.WriteLine("Area = " + area);
            Console.WriteLine("Perimeter = " + perimeter);
        }
    }
}
