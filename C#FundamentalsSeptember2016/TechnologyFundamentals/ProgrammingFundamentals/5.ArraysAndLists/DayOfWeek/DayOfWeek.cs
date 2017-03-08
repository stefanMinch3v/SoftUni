using System;

namespace DayOfWeek
{
    public class DayOfWeek
    {
        public static void Main(string[] args)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int choose = int.Parse(Console.ReadLine());
            if (choose >= 1 && choose <= 7)
            {
                Console.WriteLine(days[choose - 1]);
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }
        }
    }
}
