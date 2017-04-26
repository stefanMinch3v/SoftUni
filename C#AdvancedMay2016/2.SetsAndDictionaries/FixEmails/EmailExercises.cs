using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EmailExercises
{
    public static void Main(string[] args)
    {
        Dictionary<string, string> emails = new Dictionary<string, string>();
        string input = Console.ReadLine();

        while (!input.Contains("stop"))
        {
            string username = input;
            string mail = Console.ReadLine();
            if (mail.Substring(mail.Length - 2) == "uk" || mail.Substring(mail.Length - 2) == "us")
            {
                goto end;
            }
            else
            {
                FixEmails(username, mail, emails);
            }

            end: input = Console.ReadLine();
        }

        foreach (var kvp in emails)
        {
            var key = kvp.Key;
            var value = kvp.Value;
            Console.WriteLine($"{key} -> {value}");
        }
    }

    private static void FixEmails(string username, string mail, Dictionary<string, string> emails)
    {
        if (!emails.ContainsKey(username))
        {
            emails[username] = mail;
        }
    }
}
