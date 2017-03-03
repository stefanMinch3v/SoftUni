using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _1000DaysAfterBirth
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.Write("Write some date : ");
            string dt = Console.ReadLine();
            string mdy = "dd-MM-yyyy";
            DateTime date = DateTime.ParseExact(dt, mdy, null);
            Console.WriteLine("After 1000 days the date will be : " + date.AddDays(1000).ToString("dd-MM-yyyy"));
            //Console.WriteLine("Date is : " + date);
            //Console.WriteLine("After 1000 days the date will be : " + newDate);*/
            Console.Write("Write some date : ");
            string dateString = Console.ReadLine();
            string format = "dd-MM-yyyy";
            DateTime result = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime output = Convert.ToDateTime(result).AddDays(999);
            Console.WriteLine("The date after 1000 days will be : " + output.ToString("dd-MM-yyyy"));
        }
    }
}
