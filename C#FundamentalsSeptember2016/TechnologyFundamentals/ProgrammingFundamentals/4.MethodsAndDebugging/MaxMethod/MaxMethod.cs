using System;

namespace MaxMethod
{
    public class MaxMethod
    {
        public static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMax(num, num2, num3));
        }

        static int GetMax(int a, int b, int c)
        {
            int result = Math.Max(a, b);
            int result2 = Math.Max(result, c);
            return result2;
        }
    }
}
