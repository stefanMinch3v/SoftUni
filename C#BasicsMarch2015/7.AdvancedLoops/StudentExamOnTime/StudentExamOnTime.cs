using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExamOnTime
{
    class StudentExamOnTime
    {
        static void Main(string[] args)
        {
            var examH = int.Parse(Console.ReadLine());
            var examM = int.Parse(Console.ReadLine());
            var studentH = int.Parse(Console.ReadLine());
            var studentM = int.Parse(Console.ReadLine());
            int examTotalMins = examH * 60 + examM;
            int studentTotalMins = studentH * 60 + studentM;
            int diff = studentTotalMins - examTotalMins;
            string stringParam = "before";
            string minsOrHours = "minutes";
            string time;
            if (diff > 0)
            {
                Console.WriteLine("Late");
                stringParam = "after";
            }
            else if (diff >= -30 && diff <= 0)
            {
                Console.WriteLine("On time");
            }
            else
            {
                Console.WriteLine("Early");
            }

            int resultHours = Math.Abs(diff) / 60;
            int resultMins = Math.Abs(diff) % 60;

            if (resultHours > 0)
            {
                minsOrHours = "hours";
                time = string.Format("{0}:{1}", resultHours, resultMins.ToString().PadLeft(2, '0'));
            }
            else
            {
                time = resultMins.ToString();
            }

            Console.WriteLine("{0} {1} {2} the start", time, minsOrHours, stringParam);




             /*Druga zada4ka
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int ii = 1; ii <= m; ii++)
                {
                    
                    Console.Write(m);
                }
                Console.WriteLine();
            }
            */
        }
    }
}
