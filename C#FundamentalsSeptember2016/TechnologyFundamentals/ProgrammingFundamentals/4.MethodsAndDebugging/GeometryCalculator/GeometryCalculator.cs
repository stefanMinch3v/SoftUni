using System;

namespace GeometryCalculator
{
    public class GeometryCalculator
    {
        public static void Main(string[] args)
        {
            string type = Console.ReadLine().ToLower();
            FigureCalculator(type);

        }

        static void FigureCalculator(string type)
        {
            double sum = 0;
            switch (type)
            {
                case "triangle":
                    double side = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    sum = (side * height) / 2;
                    break;
                case "square":
                    double side1 = double.Parse(Console.ReadLine());
                    sum = side1 * side1;
                    break;
                case "rectangle":
                    double width = double.Parse(Console.ReadLine());
                    double height1 = double.Parse(Console.ReadLine());
                    sum = width * height1;
                    break;
                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    sum = Math.PI * radius * radius;
                    break;
            }
            Console.WriteLine("{0:f2}",sum);
        }
    }
}
