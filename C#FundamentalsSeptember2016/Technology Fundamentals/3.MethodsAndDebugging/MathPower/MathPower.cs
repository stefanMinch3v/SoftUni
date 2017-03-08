using System;

namespace MathPower
{
    public class MathPower
    {
        public static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            double mathPower = GetMathPower(num, power);
            Console.WriteLine(mathPower);
        }

        static double GetMathPower(double num, double power)
        {
            //return Math.Pow(num, power);
            double sum = 1;
            for (int i = 1; i <= power; i++)
            {
                sum *= num;
            }
            return sum;
        }
    }
}
