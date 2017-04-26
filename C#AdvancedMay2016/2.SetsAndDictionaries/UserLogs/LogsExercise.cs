using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LogsExercise
{
    public static void Main(string[] args)
    {
        SortedDictionary<string, Dictionary<string, int>> userLogs = new SortedDictionary<string, Dictionary<string, int>>();
        string[] input = Console.ReadLine().Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        while (!input[0].Equals("end"))
        {
            string username = input[5];
            string ipAddress = input[1];

            FillOutLogs(userLogs, username, ipAddress);
            
            input = Console.ReadLine().Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        foreach (var kvp in userLogs)
        {
            var username = kvp.Key;
            Console.WriteLine(username + ":");
            foreach (var secondKvp in kvp.Value)
            {
                var key = secondKvp.Key;
                var value = secondKvp.Value;
                if (secondKvp.Key == kvp.Value.Keys.Last())
                {
                    Console.WriteLine($"{key} => {value}.");
                }
                else
                {
                    Console.Write($"{key} => {value}, ");
                }
            }
        }
    }

    private static void FillOutLogs(SortedDictionary<string, Dictionary<string, int>> userLogs, string username, string ipAddress)
    {
        if (!userLogs.ContainsKey(username))
        {
            userLogs.Add(username, new Dictionary<string, int>());
            userLogs[username].Add(ipAddress, 1);
        }
        else
        {
            if (!userLogs[username].ContainsKey(ipAddress))
            {
                userLogs[username].Add(ipAddress, 1);
            }
            else
            {
                userLogs[username][ipAddress]++;
            }
        }

    }
}
