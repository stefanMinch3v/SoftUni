using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            bool isFoundEnd = false;

            while (!isFoundEnd)
            {
                var input = Console.ReadLine().Split().ToArray();

                if (input.Contains("END"))
                {
                    isFoundEnd = true;
                }

                else if (input.Contains("A"))
                {
                    phonebook[input[1]] = input[2];
                }

                else if (input.Contains("S"))
                {
                    if (phonebook.ContainsKey(input[1]))
                    {
                        Console.WriteLine("{0} -> {1}", input[1], phonebook[input[1]]);
                    }
                    else
                    {
                        Console.WriteLine("Contact {0} does not exist.", input[1]);
                    }
                }
                else if (input.Contains("ListAll"))
                {
                    var phoneSorted = phonebook.OrderBy(x => x.Key);
                    foreach (var item in phoneSorted)
                    {
                        Console.WriteLine(item.Key + " -> " + item.Value);
                    }
                }
            }
        }
    }
}
