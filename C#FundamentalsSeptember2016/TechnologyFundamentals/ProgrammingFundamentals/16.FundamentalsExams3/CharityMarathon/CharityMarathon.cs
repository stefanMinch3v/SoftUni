using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CharityMarathon
{
    public static void Main(string[] args)
    {
        int marathonDays = int.Parse(Console.ReadLine());//
        int numberOfRunners = int.Parse(Console.ReadLine());//
        int numberOfLaps = int.Parse(Console.ReadLine());
        int lapLength = int.Parse(Console.ReadLine());
        int capacityPerDay = int.Parse(Console.ReadLine());//
        decimal moneyPerKm = decimal.Parse(Console.ReadLine());
        decimal runnersAndMarathonDays = marathonDays * capacityPerDay;
        decimal moneyRaised = 0;

        if (runnersAndMarathonDays > numberOfRunners)
        {
            runnersAndMarathonDays = numberOfRunners;
        }

        moneyRaised = ( (runnersAndMarathonDays * numberOfLaps * lapLength) / 1000) * moneyPerKm;
        Console.WriteLine($"Money raised: {moneyRaised:f2}");
        
        
       // btw I've taught myself to do squats on 1 foot 
    }
}
