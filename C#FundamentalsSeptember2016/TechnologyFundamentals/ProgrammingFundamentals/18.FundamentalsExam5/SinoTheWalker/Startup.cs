using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        int[] time = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
        long steps = long.Parse(Console.ReadLine()) % 86400; // 1 day = 86400 sec , if the number is too big this way guarantee not overflowing
        long timeInSeconds = long.Parse(Console.ReadLine()) % 86400;

        long stepsAndSeconds = steps * timeInSeconds;

        long seconds = time[2];
        int minutes = time[1];
        int hours = time[0];

        string finalSeconds = string.Empty;
        string finalMinutes = string.Empty;
        string finalHours = string.Empty;

        seconds += stepsAndSeconds;

        while(seconds > 59)
        {
            minutes++;
            seconds -= 60;
        }
        while (minutes > 59)
        {
            hours++;
            minutes -= 60;
        }
        while (hours > 23)
        {
            hours -= 24;
        }

        if (seconds >= 0 && seconds <= 9)
        {
            finalSeconds = "0" + seconds.ToString();
        }
        else
        {
            finalSeconds = seconds.ToString();
        }
        if (minutes >= 0 && minutes <= 9)
        {
            finalMinutes = "0" + minutes.ToString();
        }
        else
        {
            finalMinutes = minutes.ToString();
        }
        if (hours >= 0 && hours <= 9)
        {
            finalHours = "0" + hours.ToString();
        }
        else
        {
            finalHours = hours.ToString();
        }
        Console.WriteLine($"Time Arrival: {finalHours}:{finalMinutes}:{finalSeconds}");

        /*
         * string inputDate = Console.ReadLine();
            int steepHome = int.Parse(Console.ReadLine())% 86400;
            int sekSteep = int.Parse(Console.ReadLine())% 86400;
 
            DateTime currentDate = DateTime.Parse(inputDate);
            long sumMinSek = steepHome * sekSteep;
            currentDate = currentDate.AddSeconds(sumMinSek);
            string output = currentDate.TimeOfDay.ToString();
            Console.WriteLine($"Time Arrival: {output}");
          */
    }
}
