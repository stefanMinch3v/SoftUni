using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareNumbers
{
    class SquareNumbers
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> square = new List<int>();

            foreach (var item in nums)
            {
                double checkSquare = Math.Sqrt(item);
                if (checkSquare == (int)checkSquare)
                {
                    square.Add(item);
                }
            }

            square.Sort((a, b) => b.CompareTo(a));
            string joint = string.Join(" ", square);
            Console.WriteLine(joint);
        }
    }
}
