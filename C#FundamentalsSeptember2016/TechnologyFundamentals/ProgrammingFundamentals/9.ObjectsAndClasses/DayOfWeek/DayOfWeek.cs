using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOfWeek
{
    public class DayOfWeek
    {
        public static void Main(string[] args)
        {
            //var input = Console.ReadLine();
            //DateTime date = DateTime.ParseExact(input, "d-M-yyyy", CultureInfo.InvariantCulture);
            //Console.WriteLine(date.DayOfWeek);

            //version - 2
            var input = Console.ReadLine().Split('-');
            var day = int.Parse(input[0]);
            var month = int.Parse(input[1]);
            var year = int.Parse(input[2]);
            DateTime date = new DateTime(year, month, day);
            Console.WriteLine("{0}", date.DayOfWeek);
        }
    }
}
