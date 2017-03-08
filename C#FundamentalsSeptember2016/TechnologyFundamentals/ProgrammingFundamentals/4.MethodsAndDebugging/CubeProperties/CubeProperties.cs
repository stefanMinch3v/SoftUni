using System;

namespace CubeProperties
{
    public class CubeProperties
    {
        public static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string type = Console.ReadLine().ToLower();
            CalculateCubeProperties(side, type);
        }

        static void CalculateCubeProperties(double side, string type)
        {
            double sum = 0;
            switch (type)
            {
                case "face":
                    sum = Math.Sqrt(2 * (side * side));
                    break;
                case "space":
                    sum = Math.Sqrt(3 * (side * side));
                    break;
                case "volume":
                    sum = side * side * side;
                    break;
                case "area":
                    sum = 6 * (side * side);
                    break;
            }
            Console.WriteLine("{0:f2}", sum);
        }
    }
}
