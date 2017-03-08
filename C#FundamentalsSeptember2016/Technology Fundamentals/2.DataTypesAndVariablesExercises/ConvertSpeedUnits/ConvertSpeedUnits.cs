
using System;

namespace ConvertSpeedUnits
{
    public class ConvertSpeedUnits
    {
        public static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            float time = (float)Math.Ceiling((double)(hours * 3600 + minutes * 60 + seconds));
            float metersPerSeconds = meters / time;
            float kmPerHour = (metersPerSeconds * 18) / 5.0f;
            float milesPerHour = kmPerHour / 1.609f;

            Console.WriteLine(metersPerSeconds);
            Console.WriteLine(kmPerHour);
            Console.WriteLine(milesPerHour);
        }
    }
}
