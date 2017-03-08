using System;

namespace CalculateTriangleArea
{
    public class CalculateTriangleArea
    {
        public static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = GetTriangleArea(width, height);
            Console.WriteLine(area);
        }

        static double GetTriangleArea(double width, double height)
        {
            double area = (width * height) / 2;
            return area;
        }
    }
}
