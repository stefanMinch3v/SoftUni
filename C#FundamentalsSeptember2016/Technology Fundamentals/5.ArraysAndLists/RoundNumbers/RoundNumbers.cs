using System;

namespace RoundNumbers
{
    public class RoundNumbers
    {
        public static void Main(string[] args)
        {
            string values = Console.ReadLine();
            string[] items = values.Split(' ');

            double[] arr = new double[items.Length];

            int[] roundedNums = new int[arr.Length];

            for (int i = 0; i < items.Length; i++)
            {
                arr[i] = double.Parse(items[i]);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                roundedNums[i] = (int)Math.Round(arr[i], MidpointRounding.AwayFromZero);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i]} -> {roundedNums[i]}");
            }
        }
    }
}
