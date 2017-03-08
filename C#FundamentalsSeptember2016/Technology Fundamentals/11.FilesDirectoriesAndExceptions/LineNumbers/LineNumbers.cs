using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines("Input.txt");

            for (int i = 0; i < file.Length; i++)
            {
                File.AppendAllText("Output.txt",$"{i + 1}. {file[i]}\r\n");
            }
        }
    }
}
