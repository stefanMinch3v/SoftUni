using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        string[] drivers = Console.ReadLine().Split();
        List<double> zones = Console.ReadLine().Split().Select(double.Parse).ToList();
        List<long> checkpoints = Console.ReadLine().Split().Select(long.Parse).ToList();

        for (int i = 0; i < drivers.Length; i++)
        {
            char driver = drivers[i][0];
            double sum = driver;
            int zoneReached = 0;

            for (int k = 0; k < zones.Count; k++)
            {
                double zone = zones[k];
                if (checkpoints.Contains(k)) //checkpoints.Any(x => x == zones.IndexOf(zone)) - 90/100
                {
                    sum += zone;
                } 
                else
                {
                    sum -= zone;
                }
                if (sum <= 0)
                {
                    zoneReached = k;
                    break;
                } 
            }

            if (sum > 0)
            {
                Console.WriteLine($"{drivers[i]} - fuel left {sum:f2}");
            }
            else
            {
                Console.WriteLine($"{drivers[i]} - reached {zoneReached}");
            }
        }
    }
}
