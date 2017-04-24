using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        int wingFlaps = int.Parse(Console.ReadLine());
        decimal distance = decimal.Parse(Console.ReadLine());
        int endurance = int.Parse(Console.ReadLine());
        
        decimal allDistance = (wingFlaps / 1000) * distance;
        int wingFlapsPerSecond = wingFlaps / 100;
        int rests = wingFlaps / endurance;
        long allSeconds = (rests * 5L) + wingFlapsPerSecond;

        Console.WriteLine($"{allDistance:f2} m.");
        Console.WriteLine($"{allSeconds} s.");
    }
}
