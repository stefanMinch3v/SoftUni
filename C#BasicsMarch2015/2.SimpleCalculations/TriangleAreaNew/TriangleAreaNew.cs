using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleAreaNew
{
    class TriangleAreaNew
    {
        static void Main(string[] args)
        {
            Console.Write("Height = ");
            double height = double.Parse(Console.ReadLine());
            Console.Write("Width = ");
            double width = double.Parse(Console.ReadLine());
            double area = width * height / 2;
            Console.WriteLine("Triangle area = " + Math.Round(area, 2));
        }
    }
}
