using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        double result = Dates.CalculateDays(firstDate, secondDate);
        Console.WriteLine(result);
    }
}
