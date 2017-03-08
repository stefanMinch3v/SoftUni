using System;
using System.Linq;

namespace ReverseArrayOfInteger
{
    public class ReverseArrayOfInteger
    {
        public static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            /*
            Array.Reverse(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            */
            
            for (int i = n-1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
            
            /*
            string values = Console.ReadLine();
            string[] items = values.Split(' ');

            double[] arr = new double[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                arr[i] = double.Parse(items[i]);
            }*/

        }
    }
}
