using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main(string[] args)
    {
        string[] readFirst = File.ReadLines("02_OddLines/01_FileOne.txt").ToArray();
        string[] readSecond = File.ReadLines("02_OddLines/01_FileTwo.txt").ToArray();

        foreach (var word in readFirst)
        {
            File.AppendAllText("02_OddLines/test.txt", word + Environment.NewLine);//write to new file
        }
        foreach (var word in readSecond)
        {
            File.AppendAllText("02_OddLines/test.txt", word + Environment.NewLine);//write to new file
        }
    }
}
