using System;

namespace EnglishNameOfLastDigit
{
    public class EnglishNameOfLastDigit
    {
        public static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            Console.WriteLine(NameOfLastDigit(number));
        }

        static string NameOfLastDigit(long number)
        {
            string digit = "";
            long last = Math.Abs(number % 10);

            switch (last)
            {
                case 0:
                    digit = "zero";
                    break;
                case 1:  
                    digit = "one";
                    break;
                case 2:
                    digit = "two";
                    break;
                case 3:
                    digit = "three";
                    break;
                case 4:
                    digit = "four";
                    break;
                case 5:
                    digit = "five";
                    break;
                case 6:
                    digit = "six";
                    break;
                case 7:
                    digit = "seven";
                    break;
                case 8:
                    digit = "eight";
                    break;
                case 9:
                    digit = "nine";
                    break;
            }
            return digit;
        }
    }
}
