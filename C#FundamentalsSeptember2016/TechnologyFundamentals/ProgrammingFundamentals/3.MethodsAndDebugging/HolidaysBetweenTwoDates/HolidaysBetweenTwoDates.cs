using System;
using System.Globalization;

namespace HolidaysBetweenTwoDates
{
    public class HolidaysBetweenTwoDates
    {
        public static void Main(string[] args)
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(),"d.M.yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(),"d.M.yyyy", CultureInfo.InvariantCulture);
            int holidaysCount = 0;
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                if (date.DayOfWeek.Equals(DayOfWeek.Saturday) || 
                    date.DayOfWeek.Equals(DayOfWeek.Sunday)) holidaysCount++;
            Console.WriteLine(holidaysCount);
        }
    }
}
