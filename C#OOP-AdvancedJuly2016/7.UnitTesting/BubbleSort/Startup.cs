namespace BubbleSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Bubble bubble = new Bubble();

            List<int> collection = new List<int>() { 12, 22, 1, 88, 135, 6, 2, 113};
            bubble.Sort(collection);

            Console.WriteLine(string.Join(", ", collection));
        }

    }
}
