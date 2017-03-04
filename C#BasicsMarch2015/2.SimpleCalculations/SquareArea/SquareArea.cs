using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine()); //var a = int.Parse(Console.ReadLine());
            int area = a * a; // var area = a * a;
            Console.Write("Square = ");
            Console.WriteLine(area);
        }
    }
}
