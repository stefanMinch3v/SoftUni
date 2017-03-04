using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadianToDegree
{
    class RadiansToDegrees
    {
        static void Main(string[] args)
        {
            Console.Write("Radians = ");
            double radians = double.Parse(Console.ReadLine());
            double calculate =  180 / Math.PI * radians;
            Console.WriteLine("Degree = {0}",Math.Round(calculate,1));
        }
    }
}
