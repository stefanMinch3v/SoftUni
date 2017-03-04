using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapezoidArea
{
    class TrapezoidArea
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the unique formula of the trapezoid area! Please enter the details to calculate");
            Console.Write("The one side of the trapezoid: ");
            double b1 = double.Parse(Console.ReadLine());
            Console.Write("The other side of the trapezoid: ");
            double b2 = double.Parse(Console.ReadLine());
            Console.Write("The height of the trapezoid: ");
            double h = double.Parse(Console.ReadLine());
            double area = (b1 + b2) * h / 2;
            Console.WriteLine("Trapezoid area = " + area); 
        }
    }
}
