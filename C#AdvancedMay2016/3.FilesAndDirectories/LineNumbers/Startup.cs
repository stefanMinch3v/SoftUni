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
        string[] read = File.ReadLines("02_OddLines/lineIn.txt").ToArray();//read from some file

        for (int i = 0; i < read.Length; i++)
        {
            File.AppendAllText("02_OddLines/test.txt", i + 1 + ". " + read[i] + Environment.NewLine);//write to new file
        }
    }
}
