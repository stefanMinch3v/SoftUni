using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountWorkingDays
{
    public class CountWorkingDays
    {
        public static void Main(string[] args)
        {
            /*
            string[] startRead = Console.ReadLine().Split('-');
            string[] endRead = Console.ReadLine().Split('-');

            int day = int.Parse(startRead[0]);
            int month = int.Parse(startRead[1]);
            int year = int.Parse(startRead[2]);

            int day2 = int.Parse(endRead[0]);
            int month2 = int.Parse(endRead[1]);
            int year2 = int.Parse(endRead[2]);

            DateTime startDate = new DateTime(year, month, day);
            DateTime endDate = new DateTime(year2, month2, day2);
            */
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateTime startDate = DateTime.ParseExact(firstDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(secondDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            int countWorkingDays = 0;
            /*
            DateTime[] holidays = new DateTime[]
                {
                    new DateTime(1, 1, 1),
                    new DateTime(1, 3, 3),
                    new DateTime(1, 5, 1),
                    new DateTime(1, 5, 6),
                    new DateTime(1, 5, 24),
                    new DateTime(1, 9, 6),
                    new DateTime(1, 9, 22),
                    new DateTime(1, 11, 1),
                    new DateTime(1, 12, 24),
                    new DateTime(1, 12, 25),
                    new DateTime(1, 12, 26)
                };
                */
            List<DateTime> holidays = new List<DateTime>();
            holidays.Add(new DateTime(2016, 01, 01));
            holidays.Add(new DateTime(2016, 03, 03));
            holidays.Add(new DateTime(2016, 05, 01));
            holidays.Add(new DateTime(2016, 05, 06));
            holidays.Add(new DateTime(2016, 05, 24));
            holidays.Add(new DateTime(2016, 09, 06));
            holidays.Add(new DateTime(2016, 09, 22));
            holidays.Add(new DateTime(2016, 01, 11));
            holidays.Add(new DateTime(2016, 12, 24));
            holidays.Add(new DateTime(2016, 12, 25));
            holidays.Add(new DateTime(2016, 12, 26));

            for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {
                DateTime newDate = new DateTime(2016, currentDate.Month, currentDate.Day);
                if (! holidays.Contains(newDate) && currentDate.DayOfWeek != DayOfWeek.Sunday && currentDate.DayOfWeek != DayOfWeek.Saturday)
                {
                    countWorkingDays++;
                }
            }

            Console.WriteLine(countWorkingDays);
        }
    }
}
