using System;
using System.Numerics;
namespace FactorialTrailingZeroes
{
    public class FactorialTrailingZeroes
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            BigInteger result = FactorialNumber(number);
            int countZERO = CountZeroes(result);
            Console.WriteLine(countZERO);
            Console.WriteLine("Number is:");
            Console.WriteLine(result);
        }

        static BigInteger FactorialNumber(int number)
        {
            BigInteger fact = 1;
            do
            {
                fact = fact * number;
                number--;
            } while (number > 1);
            return fact;
        }

        static int CountZeroes(BigInteger number)
        {
            int countZero = 0;
            while (number > 0)
            {
                BigInteger divide = number % 10;
                if (divide == 0)
                {
                    countZero++;
                }
                else
                {
                    break;
                }
                number /= 10;
            }
            return countZero; 
        }
    }
}
