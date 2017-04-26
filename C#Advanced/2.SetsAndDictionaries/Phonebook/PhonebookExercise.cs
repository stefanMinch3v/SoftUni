using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PhonebookExercise
{
    public static void Main(string[] args)
    {
        Dictionary<string, string> phonebook = new Dictionary<string, string>();
        string[] input = Console.ReadLine().Split(new char[] { '-' });

        while (!input[0].Contains("search"))
        {
            string name = input[0];
            string phone = input[1];

            FillOutPhonebook(name, phone, phonebook);
            input = Console.ReadLine().Split(new char[] { '-' });
        }

        string search = Console.ReadLine();
        while (!search.Contains("stop"))
        {
            if (!phonebook.ContainsKey(search))
            {
                Console.WriteLine($"Contact {search} does not exist.");
            }
            else
            {
                foreach (var kvp in phonebook)
                {
                    if (kvp.Key.Contains(search))
                    {
                        var key = kvp.Key;
                        var value = kvp.Value;
                        Console.WriteLine($"{key} -> {value}");
                    }
                }
            }
            search = Console.ReadLine();
        }
    }

    private static void FillOutPhonebook(string name, string phone, Dictionary<string, string> phonebook)
    {
        if (!phonebook.ContainsKey(name))
        {
            phonebook.Add(name, string.Empty);
        }
        phonebook[name] = phone;
    }
}
