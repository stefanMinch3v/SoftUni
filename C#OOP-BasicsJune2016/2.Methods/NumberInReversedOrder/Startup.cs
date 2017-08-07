using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        string number = Console.ReadLine();
        DecimalNumber decimalNumber = new DecimalNumber();
        Console.WriteLine(decimalNumber.ReversedNumber(number));
    }
}
