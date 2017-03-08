using System;

namespace MultiplyEvenOdd
{
    public class MultiplyEvenOdd
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int result = GetMultiplyEvensAndOdds(number);
            Console.WriteLine(result);
        }

        private static int GetMultiplyEvensAndOdds(int number)
        {
            int even = GetSumOfEvens(number);
            int odd = GetSumOfOdds(number);

            int sum = even * odd;
            return sum;
        }

        private static int GetSumOfEvens(int number)
        {
            int sum = 0;
            while (Math.Abs(number) > 0)
            {
                int lastNum = number % 10;
                if (lastNum % 2 == 0)
                {
                    sum += lastNum;
                }
                number /= 10;
            }
            return sum;
        }

        private static int GetSumOfOdds(int number)
        {
            int sum = 0;
            while (Math.Abs(number) > 0)
            {
                int lastNum = number % 10;
                if (lastNum % 2 != 0)
                {
                    sum += lastNum;
                }
                number /= 10;
            }
            return sum;
        }
    }
}
