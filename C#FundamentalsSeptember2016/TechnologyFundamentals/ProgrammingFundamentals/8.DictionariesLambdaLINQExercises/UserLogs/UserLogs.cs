using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogs
{
    public class UserLogs
    {
        public static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, List<string>>> logs = new SortedDictionary<string, Dictionary<string, List<string>>>();

            string consoleRead = Console.ReadLine();

            while (!consoleRead.Equals("end"))
            {
                string[] input = consoleRead.Split().ToArray();

                string username = input[2].Substring(5);
                string message = input[1].Substring(8);
                string ip = input[0].Substring(3);

                InsertUsername(logs, username);
                InsertIpAndMessage(logs, username, ip, message);

                consoleRead = Console.ReadLine();
            }
            PrintAllResults(logs);

        }

        private static void PrintAllResults(SortedDictionary<string, Dictionary<string, List<string>>> logs)
        {
            /*foreach (var user in logs)
            {
                string username = user.Key;
                
                var message = user.Value.Values.Select(x => x.Count).ToList();
                string messages = string.Join(" ", message);

                var ip = user.Value.Keys.Distinct().ToList();
                string ips = string.Join(", ", ip);
                Console.WriteLine("{0}: \n{1} => {2}.", username, ips, messages);

            }*/
            foreach (var user in logs)
            {
                Console.WriteLine($"{user.Key}: ");
                foreach (var ipAddress in user.Value)
                {
                    if (ipAddress.Key == user.Value.Keys.Last())
                    {
                        Console.WriteLine($"{ipAddress.Key} => {ipAddress.Value.Count()}.");
                    }
                    else
                    {
                        Console.Write($"{ipAddress.Key} => {ipAddress.Value.Count()}, ");
                    }
                }
            }
        }

        private static void InsertIpAndMessage(SortedDictionary<string, Dictionary<string, List<string>>> logs, string username, string ip, string message)
        {
            if (!logs[username].ContainsKey(ip))
            {
                logs[username].Add(ip, new List<string>());
            }
            logs[username][ip].Add(message);
        }

        private static void InsertUsername(SortedDictionary<string, Dictionary<string, List<string>>> logs, string username)
        {
            if (!logs.ContainsKey(username))
            {
                logs.Add(username, new Dictionary<string, List<string>>());
            }
        }
    }
}
