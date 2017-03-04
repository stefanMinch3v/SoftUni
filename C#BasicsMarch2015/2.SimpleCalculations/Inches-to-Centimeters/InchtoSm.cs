using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inches_to_Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inches = ");
            double inch = double.Parse(Console.ReadLine());
            double sm = inch * 2.54f;
            Console.Write("Sentimeters = ");
            Console.WriteLine(sm);
        }
    }
}
