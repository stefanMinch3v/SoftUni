using System;
using System.Linq;

namespace ReverseString
{
    public class ReverseString
    {
        public static void Main()
        {
            var s = Console.ReadLine().Split(' ').ToArray();

            //string[] arr = s.Split(' ');
            string[] reverse = new string[s.Length];

            int j = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                reverse[j] = s[i];
                j++;
            }
            for (int i = 0; i < reverse.Length; i++)
            {
                Console.Write(reverse[i] + " ");
            }
            Console.WriteLine();
            /*
            //new way

            for (int i = 0; i < arr.Length / 2; i++)
            {
                string tmp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = tmp;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            */
        }
    }
}
