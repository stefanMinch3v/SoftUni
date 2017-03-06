using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInRectangle
{
    class PointInRectangle
    {
        static void Main(string[] args)
        {
            Console.Write("X1 = ");
            var x1 = double.Parse(Console.ReadLine());
            Console.Write("Y1 = ");
            var y1 = double.Parse(Console.ReadLine());
            Console.Write("X2 = ");
            var x2 = double.Parse(Console.ReadLine());
            Console.Write("Y2 = ");
            var y2 = double.Parse(Console.ReadLine());
            Console.Write("X = ");
            var x = double.Parse(Console.ReadLine());
            Console.Write("Y = ");
            var y = double.Parse(Console.ReadLine());
            if(x >= x1 && x <= x2 && y >= y1 && y <= y2)
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Outside");
            }
        }
    }
}
