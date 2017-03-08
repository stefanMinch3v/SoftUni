using System;

namespace RectangleProperties
{
    public class RectangleProperties
    {
        public static void Main(string[] args)
        {
            float width = float.Parse(Console.ReadLine());
            float height = float.Parse(Console.ReadLine());

            float perimeter, area;
            perimeter = 2 * (width + height);
            area = width * height;
            double diagonal = Math.Sqrt((width * width) + (height * height));

            Console.WriteLine($"{perimeter}\n{area}\n{diagonal}");
        }
    }
}
