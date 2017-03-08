using System;
using System.Text;

namespace ReverseNumber
{
    public class ReverseNumber
    {
        public static void Main(string[] args)
        {
            string number = Console.ReadLine();
            string result = ReverseDigit3(number);
            Console.WriteLine(result);
        }

        static string ReverseDigit(string number)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = number.Length - 1; i >= 0; i--)
            {
                builder.Append(number[i]);
            }
            string reverse = builder.ToString();

            return reverse;
        }

        static string ReverseDigit2(string number)
        {
            char[] arr = number.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        static string ReverseDigit3(string number)
        {
            decimal validNumber = decimal.Parse(number);
            string result = "";
            for (int i = number.Length - 1; i >= 0; i--)
            {
                result += number[i];
            }
            return result;
        }
    }
}
