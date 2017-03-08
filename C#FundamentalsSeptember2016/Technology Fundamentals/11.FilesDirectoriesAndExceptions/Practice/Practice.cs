using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


public class Practise
{
    public static void Main(string[] args)
    {
        string[] file = File.ReadAllLines("Input.txt");

        for (int i = 0; i < file.Length; i++)
        {
            if (i % 2 != 0)
            {
                File.AppendAllText("Output.txt", $"{file[i]}\r\n");
            }
        }
    }
}

