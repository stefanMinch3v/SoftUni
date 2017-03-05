using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumSeconds
{
    class SumSeconds
    {
        static void Main(string[] args)
        {
            Console.Write("First : ");
            var sec = int.Parse(Console.ReadLine());
            Console.Write("Second : ");
            var sec2 = int.Parse(Console.ReadLine());
            Console.Write("Third : ");
            var sec3 = int.Parse(Console.ReadLine());
            var secs = sec + sec2 + sec3;
            var min = 0;
            if(secs > 59)
            {
                min++;
                secs -= 60;
            }
            if (secs > 59)
            {
                min++;
                secs -= 60;
            }
            if(secs < 10)
            {
                Console.WriteLine(min + ":" + "0" + secs);
            }
            else
            {
                Console.WriteLine(min + ":" + secs);
            }
        }
    }
}
