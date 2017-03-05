using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravellingStudent
{
    class TheTravellingStudent
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program that shows your cheapest way to travel");
            Console.Write("Enter some km : ");
            var km = float.Parse(Console.ReadLine());
            Console.Write("Enter the travelling time(day or night): ");
            var time = Console.ReadLine();
            if(km < 20 && time == "day")
            {
                float sum = 0.70f + km * 0.79f;
                Console.WriteLine("The money of your travelling is(Travel by taxi): " + sum);
            }
            else if (km < 20 && time == "night")
            {
                float sum = 0.70f + km * 0.90f;
                Console.WriteLine("The money of your travelling is(Travel by taxi): " + sum);
            }

            if((km > 20 && km < 100 && time == "day") || (km > 20 && km < 100 && time == "night"))
            {
                float sum = km * 0.09f;
                Console.WriteLine("The money of your travelling is(Travel by bus): " + sum);
            }

            if ((km > 100 && km < 5000 && time == "day") || (km > 100 && km < 5000 && time == "night"))
            {
                float sum = km * 0.06f;
                Console.WriteLine("The money of your travelling is(Travel by train): " + sum);
            }

            if(km > 5000)
            {
                Console.WriteLine("Just use a plane");
            }
            Console.WriteLine("Have a nice trip");
        }
    }
}
