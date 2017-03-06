using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterEvenNumber
{
    class EnterEvenNumber
    {
        static void Main(string[] args)
        {
            /*int n = 0;
            while (true)
            {
                n = int.Parse(Console.ReadLine());
                if (n % 2 == 0)
                {
                    break;
                }
                Console.WriteLine("Invalid number");
            }
            Console.WriteLine(n);*/
            int n = 0;
            while (true)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                    if (n % 2 == 0)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid number");
                }
                catch (Exception)
                {

                    Console.WriteLine("{0} is not a number", n); ;
                }
            }
        }
    }
}
