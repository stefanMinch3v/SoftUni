using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            int treated = 0;
            int untreated = 0;

            for (int i = 0; i < num; i++)
            {
                var patients = int.Parse(Console.ReadLine());

                if (patients <= 7)
                {
                    treated += 7;
                }
                if (patients > 7)
                {
                    untreated++;
                }
                if (untreated > treated)
                {
                    untreated--;
                }
            }
            Console.WriteLine("Treated patients: {0}.", treated);
            Console.WriteLine("Untreated patients: {0}.", untreated);
        }
    }
}
