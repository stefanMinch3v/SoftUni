using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusScore
{
    class BonusScore
    {
        static void Main(string[] args)
        {
            Console.Write("Enter some score : ");
            var num = float.Parse(Console.ReadLine());
            double bonusScore = 0.0f;
            if (num < 100)
            {
                bonusScore = 5;
            }
            else if (num > 100)
            {
                bonusScore = num * 0.20;
            }
            else if (num > 1000)
            {
                bonusScore = num * 0.10;
            }

            if (num % 10 == 5)
            {
                bonusScore += 2;
            }
            else if (num % 2 == 0)
            {
                bonusScore += 1;
            }
            Console.WriteLine("Bonus score : " + bonusScore);
            Console.WriteLine("Total score is : {0}", num + bonusScore);
        }
    }
}
