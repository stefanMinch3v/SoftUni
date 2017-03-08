using System;

namespace MasterNumber
{
    public class MasterNumber
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i <= number; i++)
            {
                if (IsPalindrome(i) && SumOfDigits(i) && ContainsEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsPalindrome(int x)
        {
            bool palindrome = false;

            if (x < 0)
            {
                return palindrome;
            }

            int div = 1;
            while (x / div >= 10)
            {
                div *= 10;
            }

            while (x != 0)
            {
                int l = x / div;
                int r = x % 10;
                if (l != r)
                {
                    return palindrome;
                }
                x = (x % div) / 10;
                div /= 100;
            }
            palindrome = true;
            return palindrome;
            /*
            int a = x;
            int b = 0;
            while (a >= b)
            {
                if (a == b) return true;
                b = 10 * b + a % 10;
                if (a == b) return true;
                a = a / 10;
            }
            return false;*/
        }

        static bool SumOfDigits(int number)
        {
            bool hasSeven = false;
            int sum = 0;  
            while (number > 0)
            {
                sum = sum + (number % 10);
                number /= 10;
            }
            if (sum % 7 == 0)
            {
                hasSeven = true;
            }
            return hasSeven;
        }

        static bool ContainsEvenDigit(int number)
        {
            bool even = false;
            while (number > 0)
            {
                int sum = number % 10;
                if (sum % 2 == 0)
                {
                    even = true;
                }
                number /= 10;
            }
            return even;
        }
    }
}
