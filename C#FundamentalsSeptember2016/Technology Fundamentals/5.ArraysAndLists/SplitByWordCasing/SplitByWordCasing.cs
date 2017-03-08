using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitByWordCasing
{
    class SplitByWordCasing
    {
        public static void Main()
        {
            string sequence = Console.ReadLine();
            string[] words = sequence.Split(new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[',
            ']', ' '}, StringSplitOptions.RemoveEmptyEntries);

            List<string> lower = new List<string>();
            List<string> upper = new List<string>();
            List<string> mixed = new List<string>();

            int countLower = 0;
            int countUpper = 0;

            foreach (var item in words)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    if (char.IsLetter(item[i]) && char.IsUpper(item[i]))
                    {
                        countUpper++;
                    }
                    else if (char.IsLetter(item[i]) && char.IsLower(item[i]))
                    {
                        countLower++;
                    }
                    else
                    {
                        countUpper++;
                        countLower++;
                    }

                }
                if (countLower > 0 && countUpper == 0)
                {
                    lower.Add(item);
                }
                else if (countUpper > 0 && countLower == 0)
                {
                    upper.Add(item);
                }
                else
                {
                    mixed.Add(item);
                }

                countLower = 0;
                countUpper = 0;
            }

            string join1 = string.Join(", ", lower);
            string join2 = string.Join(", ", upper);
            string join3 = string.Join(", ", mixed);

            Console.WriteLine("Lower-case: {0}", join1);
            Console.WriteLine("Mixed-case: {0}", join3);
            Console.WriteLine("Upper-case: {0}", join2);

        }
    }
}
