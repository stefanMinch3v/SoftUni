using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSameWords
{
    class TheSameWords
    {
        static void Main(string[] args)
        {
            Console.Write("Enter some word: ");
            var word = Console.ReadLine();
            word = word.ToLower();
            Console.Write("Enter another word: ");
            var word2 = Console.ReadLine();
            word2 = word2.ToLower();
            if (word == word2)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
