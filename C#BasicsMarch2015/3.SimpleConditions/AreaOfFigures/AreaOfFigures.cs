using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures
{
    class AreaOfFigures
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a figure(square,rectangle,circle or triangle): ");
            var figure = Console.ReadLine();
            if (figure == "square")
            {
                Console.Write("Enter a number: ");
                var num = double.Parse(Console.ReadLine());
                num *= num;
                Console.WriteLine("Area is: " + Math.Round(num, 3));
            }
            else if (figure == "rectangle")
            {
                Console.Write("Enter a number: ");
                var num = double.Parse(Console.ReadLine());
                Console.Write("Enter another number: ");
                var num2 = double.Parse(Console.ReadLine());
                double area = num * num2;
                Console.WriteLine("Area is: " + Math.Round(area, 3));
            }
            else if (figure == "circle")
            {
                Console.Write("Enter a number: ");
                var num = double.Parse(Console.ReadLine());
                double area = Math.PI * num * num;
                Console.WriteLine("Area is: " + Math.Round(area, 3));
            }
            else if (figure == "triangle")
            {
                Console.Write("Enter a number: ");
                var num = double.Parse(Console.ReadLine());
                Console.Write("Enter another number(h): ");
                var num2 = double.Parse(Console.ReadLine());
                double area = (num * num2) / 2;
                Console.WriteLine("Area is: " + Math.Round(area, 3));
            }
        }
    }
}
