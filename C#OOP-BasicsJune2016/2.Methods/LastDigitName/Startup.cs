using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    static void Main()
    {
        string takeNumber = Console.ReadLine();
        Number number = new Number(takeNumber);
        Console.WriteLine(number.GetLastNumEnglishName());
    }
}
