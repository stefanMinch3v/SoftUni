using System;

namespace ComparingFloats
{
    public class ComparingFloats
    {
        public static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());

            double difference = Math.Abs(number - number2);
            const double eps = 0.000001;
            if (difference < eps)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
