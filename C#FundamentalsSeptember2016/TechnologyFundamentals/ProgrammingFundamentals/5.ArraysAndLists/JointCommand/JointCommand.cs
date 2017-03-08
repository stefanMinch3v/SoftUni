using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JointCommand
{
    class JointCommand
    {
        static void Main(string[] args)
        {
            /*
            int[] arr = { 1, 2, 3, 4, 5 };

            string concat = string.Join(", ", arr);
            Console.WriteLine(concat);
            */
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            string concat = string.Join(", ", arr);
            Console.WriteLine(concat);

        }
    }
}
