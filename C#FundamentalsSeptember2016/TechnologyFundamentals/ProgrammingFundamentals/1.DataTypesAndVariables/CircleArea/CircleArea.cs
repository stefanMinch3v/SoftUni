using System;
    using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleArea
{
    class CircleArea
    {
        static void Main(string[] args)
        {
            Console.Write("Enter radius: ");
            double r = double.Parse(Console.ReadLine());
            double sum = Math.PI * r * r;
            Console.WriteLine("{0:f12}",sum);
        }
    }
}
