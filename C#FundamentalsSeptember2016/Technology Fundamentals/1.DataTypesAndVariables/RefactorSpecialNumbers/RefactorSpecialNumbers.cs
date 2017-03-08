using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorSpecialNumbers
{
    class RefactorSpecialNumbers
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                int countNextNum = 0;
                int sumNum = 0;
                countNextNum = i;
                while (countNextNum > 0)
                {
                    sumNum += countNextNum % 10;
                    countNextNum /= 10;
                }
                bool specialNum = (sumNum == 5) || (sumNum == 7) || (sumNum == 11);
                Console.WriteLine($"{i} -> {specialNum}");
            }
        }
    }
}
