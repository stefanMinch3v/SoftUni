using System;

namespace TripleSum
{
    public class TripleSum
    {
        public static void Main()
        {
            string n = Console.ReadLine();

            string[] items = n.Split(' ');
            int[] arr = new int[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                arr[i] = int.Parse(items[i]);
            }
            //long[] arr = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();zamestva pyrvite redove kod , no iziskva Linq kolekciq
            bool result = false;
            for (int a = 0; a < arr.Length; a++)
            {
                for (int b = a+1; b < arr.Length; b++)
                {
                    for (int c = 0; c < arr.Length; c++)
                    {
                        if (arr[a] + arr[b] == arr[c])
                        {
                            Console.WriteLine(arr[a] + " + " + arr[b] + " == " + arr[c]);
                            result = true;
                        }
                    }
                }
            }
            if (!result) 
            {
                Console.WriteLine("No");
            }
        }
    }
}
