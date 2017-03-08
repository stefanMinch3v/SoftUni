using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
    public class LogsAggregator
    {
        public static void Main()
        {
            SortedDictionary<string, SortedDictionary<string, int>> logs = new SortedDictionary<string, SortedDictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] readLine = Console.ReadLine().Split().ToArray();

                string username = readLine[1];
                string ipAddress = readLine[0];
                int duration = int.Parse(readLine[2]);

                AddUsername(logs, username);
                AddIpAndDuration(logs, username, ipAddress, duration);
            }

            PrintAndSumResults(logs);
        }

        private static void PrintAndSumResults(SortedDictionary<string, SortedDictionary<string, int>> logs)
        {
            foreach (var user in logs)
            {
                string username = user.Key;
                var sumDuration = user.Value.Values.Sum();

                List<string> ipAddress = user.Value.Keys.Distinct().ToList();
                string concatIPaddresses = string.Join(", ", ipAddress);

                Console.WriteLine("{0}: {1} [{2}]", username, sumDuration, concatIPaddresses);
            }
        }

        private static void AddIpAndDuration(SortedDictionary<string, SortedDictionary<string, int>> logs, string username, string ipAddress, int duration)
        {
            if (!logs[username].ContainsKey(ipAddress))
            {
                logs[username].Add(ipAddress, 0);
            }
            logs[username][ipAddress] += duration;
        }

        private static void AddUsername(SortedDictionary<string, SortedDictionary<string, int>> logs, string username)
        {
            if (!logs.ContainsKey(username))
            {
                logs.Add(username, new SortedDictionary<string, int>());
            }
        }
    }
}
