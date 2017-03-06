using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustPractise2
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;
            for (int i = 1; i <= n; i++)
            {
                Console.Write("{0} ",i*i);
                sum += i * i;
            }
            Console.WriteLine("->{0}",sum);
        }
    }
}
