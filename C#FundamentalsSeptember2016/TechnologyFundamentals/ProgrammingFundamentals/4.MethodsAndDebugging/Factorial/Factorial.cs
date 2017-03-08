using System;
using System.Numerics;
namespace Factorial
{
    public class Factorial
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            BigInteger result = FactorialNumber(number);
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
    }
}
