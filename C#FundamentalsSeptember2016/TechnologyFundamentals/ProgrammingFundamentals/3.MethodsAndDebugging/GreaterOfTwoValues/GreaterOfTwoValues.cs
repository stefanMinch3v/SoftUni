using System;

namespace GreaterOfTwoValues
{
    public class GreaterOfTwoValues
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int sum = GetMax(a, b);
            Console.WriteLine(sum);
        }

        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static string GetMax(string word, string word2)
        {
            if (word.CompareTo(word2) < 0)
            {
                return word;
            }
            else if (word.CompareTo(word2) == 0)
            {
                return "equal";
            }
            else
            {
                return word2;
            }
        }

        static char GetMax(char a, char b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}
