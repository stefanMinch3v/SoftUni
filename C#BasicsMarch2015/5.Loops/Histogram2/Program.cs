using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double counter1 = 0.0;
            double counter2 = 0.0;
            double counter3 = 0.0;
            double counter4 = 0.0;
            double counter5 = 0.0;
            double p1, p2, p3, p4, p5;

            if (n >= 1 || n <= 1000)
            {

                for (int i = 0; i < n; i++)
                {
                    int number = int.Parse(Console.ReadLine());

                    if (number >= 1 && number < 200)
                    {
                        counter1++;

                    }
                    else if (number >= 200 && number < 400)
                    {
                        counter2++;
                    }

                    else if (number >= 400 && number < 600)
                    {
                        counter3++;
                    }
                    else if (number >= 600 && number < 800)
                    {
                        counter4++;
                    }
                    else if (number >= 800 && number <= 1000)
                    {
                        counter5++;
                    }

                }


            }
            p1 = counter1 / n * 100;
            p2 = counter2 / n * 100;
            p3 = counter3 / n * 100;
            p4 = counter4 / n * 100;
            p5 = counter5 / n * 100;


            Console.WriteLine("{0:F2}% \n{1:F2}% \n{2:F2}% \n{3:F2}% \n{4:F2}%", p1, p2, p3, p4, p5);
        }
    }
}
