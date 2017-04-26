using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LogsExercise
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, Dictionary<string, int>> logs = new Dictionary<string, Dictionary<string, int>>();

        for (int i = 0; i < n; i++)
        {
            string[] commands = Console.ReadLine().Split();
            string username = commands[1];
            string ipAddress = commands[0];
            int duration = int.Parse(commands[2]);

            AggregateLogs(logs, username, ipAddress, duration);
        }

        foreach (var kvp in logs.OrderBy(u => u.Key))
        {
            var user = kvp.Key;
            var duration = kvp.Value.Values.Sum();
            var orderedKvp = kvp.Value.OrderBy(ip => ip.Key);
            Console.Write($"{user}: {duration} [");
            
            foreach (var secondKvp in orderedKvp)
            {
                var ips = secondKvp.Key;
                if (ips == orderedKvp.Last().Key)
                {
                    Console.Write($"{ips}]");
                }
                else
                {
                    Console.Write($"{ips}, ");
                }
            }
            Console.WriteLine();
        }
    }

    private static void AggregateLogs(Dictionary<string, Dictionary<string, int>> logs, string username, string ipAddress, int duration)
    {
        if (!logs.ContainsKey(username))
        {
            logs.Add(username, new Dictionary<string, int>());
            logs[username].Add(ipAddress, duration);
        }
        else
        {
            if (!logs[username].ContainsKey(ipAddress))
            {
                logs[username].Add(ipAddress, duration);
            }
            else
            {
                logs[username][ipAddress] += duration;
            }
        }
    }
}
