using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleArea
{
    class RectangleArea
    {
        static void Main(string[] args)
        {
            //Vtori na4in ---
            //double width = Math.Max(x1, x2) - Math.Min(x1, x2);
            //double height = Math.Max(y2, y1) - Math.Min(y1, y2);
            Console.WriteLine("Please fill the details in order to display the results");
            Console.Write("Angle x1= ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("Angle y1= ");
            double y1 = double.Parse(Console.ReadLine());
            Console.Write("Angle x2= ");
            double x2 = double.Parse(Console.ReadLine());
            Console.Write("Angle y2= ");
            double y2 = double.Parse(Console.ReadLine());
            double width = Math.Abs(x1-x2);
            double height = Math.Abs(y1-y2);
            double area = width * height;
            double perimeter = 2 * (width + height);
            Console.WriteLine("Area = {0}", area);
            Console.WriteLine("Perimeter = {0}", perimeter);
        }
    }
}
