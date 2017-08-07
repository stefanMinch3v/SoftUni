using System;
using System.Linq;

namespace GenericBox
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine();
                box.Add(input);
            }
            var compareInput = Console.ReadLine();
            Console.WriteLine(box.CompareTo(box.GetCollection, compareInput));

            //int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //box.SwapIndexes(indexes[0], indexes[1]);
            //foreach (var item in box.GetCollection)
            //{
            //    Console.WriteLine($"{box}: {item}");
            //}

        }
    }
}
