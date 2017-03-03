using System;

namespace RectangleArea
{
    class Rectangle
    {
        static void Main(string[] args)
        {
            var a = decimal.Parse(Console.ReadLine());
            var b = decimal.Parse(Console.ReadLine());
            var width = Math.Abs(a);
            var height = Math.Abs(b);
            var area = width * height;
            Console.WriteLine(area);
        }
    }
}
