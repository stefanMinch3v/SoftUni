using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAdd15min
{
    class TimeAdd15min
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Time after 15 min");
            Console.Write("Enter hour : ");
            var hour = int.Parse(Console.ReadLine());
            Console.Write("Enter minutes : ");
            var min = int.Parse(Console.ReadLine());
            min += 15;
            if (min > 59)
            {
                hour++;
                min -= 60;
            }
            if (min > 59)
            {
                hour++;
                min -= 60;
            }
            if (hour > 23)
            {
                hour -= 24;
            }
            if(min < 10)
            {
                Console.WriteLine(hour + ":" + "0" + min);
            }
            else
            {
                Console.WriteLine(hour + ":" + min);
            }
            */
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());
            minute = minute + 15;
            while (minute > 59)
            {
                hour++;
                minute -= 60;
            }
            if (hour > 23)
            {
                hour = 0;
            }
            if (minute < 10)

            {
                Console.WriteLine("{0}:0{1}", hour, minute);
            }
            else
            {
                Console.WriteLine("{0}:{1}", hour, minute);
            }
            
        }
    }
}
