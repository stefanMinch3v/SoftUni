using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Elevator
    {
        static void Main(string[] args)
        {
            
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int elevator = (int)Math.Ceiling((double) people / capacity);
            Console.WriteLine(elevator);
            /*
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            double sum = people / capacity;
            Console.WriteLine((int)Math.Ceiling(sum));*/
        }
    }
}
