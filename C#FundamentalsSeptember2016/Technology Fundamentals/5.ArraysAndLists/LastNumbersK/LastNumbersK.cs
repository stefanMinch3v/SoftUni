using System;

namespace LastNumbersK
{
    public class LastNumbersK
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] numbers = new long[n];
            numbers[0] = 1;

            for (int i = 1; i < n; i++)
            {
                long sum = 0;
                for (int j = i - 1; j >= 0 && j >= i-k; j--)
                {
                    sum += numbers[j];
                }
                numbers[i] = sum;
            }
            Console.WriteLine(string.Join(" ", numbers));

            /*
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] arr = new long[n];
            arr[0] = 1;

            for (int i = 1; i < n; i++)
            {
                int start = i - k;
                int end = i - 1;
                long sum = 0;
                for (int ii = start; ii <= end; ii++)
                {
                    if (ii >= 0)
                    {
                        sum += arr[ii];
                    }   
                }
                arr[i] = sum;
            }
            string join = string.Join(" ", arr);
            Console.WriteLine(join);*/
        }
    }
}
