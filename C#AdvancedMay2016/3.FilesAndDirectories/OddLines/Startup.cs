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
        string[] read = File.ReadLines("02_OddLines/01_OddLinesIn.txt").ToArray();//read from some file

        for (int i = 0; i < read.Length; i++)
        {
            if (i % 2 == 1)
            {
                File.AppendAllText("02_OddLines/test.txt", read[i] + Environment.NewLine);//write to new file
            }
        }
    }
}
