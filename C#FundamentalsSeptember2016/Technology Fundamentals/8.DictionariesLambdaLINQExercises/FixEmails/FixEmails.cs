using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
    class FixEmails
    {
        static void Main(string[] args)
        {
            /*Dictionary<string, string> phonebook = new Dictionary<string, string>();

            string username = Console.ReadLine();

            while (!username.Contains("stop"))
            {
                string email = Console.ReadLine();

                string checkEmail = email.Substring(email.Length - 2).ToLower();

                /* variant 2
                bool checkEmail = Regex.IsMatch(email, ".us", RegexOptions.IgnoreCase);
                bool checkEmail2 = Regex.IsMatch(email, ".uk", RegexOptions.IgnoreCase);

                if (!checkEmail && !checkEmail2)
                {
                    phonebook.Add(name, email);
                }

                
                

                if (!(checkEmail.Contains("us") || checkEmail.Contains("uk")))
                {
                    phonebook.Add(username, email);
                }

                username = Console.ReadLine();
            }

            foreach (var item in phonebook)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }*/

            //more complicated solution with remove from the dictrionary
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            string[] wrongEmails = {".uk", ".us" };

            string username = Console.ReadLine();

            while (!username.Contains("stop"))
            {
                string email = Console.ReadLine();

                phonebook.Add(username, email);

                username = Console.ReadLine();
            }
            RemoveWrongEmails(phonebook, wrongEmails );

            foreach (var item in phonebook)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }

        private static void RemoveWrongEmails(Dictionary<string, string> phonebook, string[] wrongEmails)
        {
            foreach (var email in wrongEmails)
            {
                var recyclePhonebook = phonebook.Where(x => x.Value.EndsWith(email)).ToList();

                foreach (var item in recyclePhonebook)
                {
                    phonebook.Remove(item.Key);
                }
            }
        }
    }
}
