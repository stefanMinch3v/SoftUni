using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllExercisesInOne
{
    class AllExercisesInOne
    {
        static void Main(string[] args)
        {
            double length, width, height;
            Console.Write("Length: ");
            length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            width = double.Parse(Console.ReadLine());
            Console.Write("Heigth: ");
            height = double.Parse(Console.ReadLine());
            double volume = (length * width * height) / 3;
            Console.WriteLine("Pyramid Volume: {0:F2}", volume);
        }
    }
}
