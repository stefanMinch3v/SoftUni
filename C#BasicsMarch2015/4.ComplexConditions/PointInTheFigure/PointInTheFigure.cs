using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class PointInsideFigure
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            bool insideDown = (x > 0) && (x < 3 * size) && (y > 0) && (y < size);
            bool insideUp = (x > size) && (x < 2 * size) && (y > 0) && (y < 4 * size);

            bool borderDown = (x >= 0 && x <= 3 * size && y == 0) || (x == 0 && y >= 0 && y <= size) || (x >= 0 && x <= size && y == size) || (x >= 2 * size && x <= 3 * size && y == size) || (x == 3 * size && y >= 0 && y <= size);

            bool borderUp = (x == size && y >= size && y <= 4 * size) || (y == 4 * size && x >= size && x <= 2 * size) || (x == 2 * size && y >= size && y <= 4 * size);

            string result = "";

            if (insideUp || insideDown)
            {
                result = "inside";
            }
            else if (borderUp || borderDown)
            {
                result = "border";
            }
            else
            {
                result = "outside";
            }
            Console.WriteLine(result);
        }
    }
}
