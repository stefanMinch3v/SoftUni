using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeWords
{
    public class RandomizeWords
    {
        public static void Main(string[] args)
        {
            var word = Console.ReadLine().Split();
            Random rnd = new Random();

            for (int i = 0; i < word.Length; i++)
            {
                int position = rnd.Next(word.Length);
                //swap (a,b)
                string temp = word[i];
                word[i] = word[position];
                word[position] = temp;
            }

            Console.WriteLine(string.Join("\r\n", word));
        }

    }
}
