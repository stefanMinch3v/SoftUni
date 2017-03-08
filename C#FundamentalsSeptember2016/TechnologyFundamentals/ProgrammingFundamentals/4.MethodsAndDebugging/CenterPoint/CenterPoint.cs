using System;

namespace CenterPodouble
{
    public class CenterPodouble
    {
        public static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double distanceToCenterA = GetDistanceBetweenPoints(x1, y1, 0, 0);
            double distanceToCenterB = GetDistanceBetweenPoints(x2, y2, 0, 0);

            if (distanceToCenterA > distanceToCenterB)
            {
                Console.WriteLine("({0}, {1})", x2, y2);
            }
            else
            {
                Console.WriteLine("({0}, {1})", x1, y1);
            }
        }

        static double GetDistanceBetweenPoints(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return distance;
        }
    }
}
