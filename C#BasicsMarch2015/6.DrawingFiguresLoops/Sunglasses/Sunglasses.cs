using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunglasses
{
    class Sunglasses
    {
        static void Main(string[] args)
        {
            /*
            int height = int.Parse(Console.ReadLine());
            string lens = new string('/', 2 * height - 2);
            string bridge = new string('|', height);
            string emptySpace = new string(' ', height);
            string lensAndFrame = string.Format("{0}{1}{0}", '*', lens);
            string frame = new string('*', 2 * height);

            for (int i = 0; i < height; i++)
            {
                if (i == 0 || i == height - 1)  //Print first and last row of the frame
                {
                    Console.WriteLine("{0}{1}{0}", frame, emptySpace);
                }
                else if (i == height / 2)   //Print midlle frame row + bridge
                {
                    Console.WriteLine("{0}{1}{0}", lensAndFrame, bridge);
                }
                else  //Print all other rows of the frame
                {
                    Console.WriteLine("{0}{1}{0}", lensAndFrame, emptySpace);
                }
            }*/
            //vtoro reshenie
            /*int input = int.Parse(Console.ReadLine());
            int size = input - 2;
            string frame = new string('*', input * 2) + new string(' ', input) + new string('*', input * 2);
            string glass = new string('*', 1) + new string('/', (input * 2) - 2) + new string('*', 1) + new string(' ', input) + new string('*', 1) + new string('/', (input * 2) - 2) + new string('*', 1);
            string middle = new string('*', 1) + new string('/', (input * 2) - 2) + new string('*', 1) + new string('|', input) + new string('*', 1) + new string('/', (input * 2) - 2) + new string('*', 1);

            Console.WriteLine(frame);
            for (int i = 0; i < size; i++)
            {
                if ((double)i == ((int)Math.Ceiling((double)size / (double)2)) - 1)
                {
                    Console.WriteLine(middle);

                }
                else
                {
                    Console.WriteLine(glass);
                }

            }
            Console.WriteLine(frame);*/

        }
    }
}


