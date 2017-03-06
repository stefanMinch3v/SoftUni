using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoom
{
    class HotelRoom
    {
        static void Main(string[] args)
        {
            var month = Console.ReadLine();
            var nights = int.Parse(Console.ReadLine());

            double apartment = 65;
            double studio = 50;

            double apartment1 = 68.70;
            double studio1 = 75.20;

            double apartment2 = 77;
            double studio2 = 76;

            if (month == "May" || month == "October")
            {
                if (nights > 7 && nights < 14)
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", apartment * nights);
                    Console.WriteLine("Studio: {0:f2} lv.", ( studio - ((studio * 5) / 100)) * nights);
                }
                else if (nights > 14)
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", ( apartment - ((apartment * 10) / 100)) * nights);
                    Console.WriteLine("Studio: {0:f2} lv.", ( studio - ((studio * 30) / 100)) * nights);
                }
                else
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", apartment * nights);
                    Console.WriteLine("Studio: {0:f2} lv.", studio * nights);
                }
            }
            else if (month == "June" || month == "September")
            {
                if (nights > 14)
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", ( apartment1 - ((apartment1 * 10) / 100)) * nights);
                    Console.WriteLine("Studio: {0:f2} lv.", ( studio1 - ((studio1 * 20) / 100)) * nights);
                }
                else
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", apartment1 * nights);
                    Console.WriteLine("Studio: {0:f2} lv.", studio1 * nights);
                }
            }
            else if (month == "July" || month == "August")
            {
                if (nights > 14)
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", ( apartment2 - ((apartment2 * 10) / 100)) * nights);
                    Console.WriteLine("Studio: {0:f2} lv.", studio2 * nights);
                }
                else
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", apartment2 * nights);
                    Console.WriteLine("Studio: {0:f2} lv.", studio2 * nights);
                }
            }
        }
    }
}
