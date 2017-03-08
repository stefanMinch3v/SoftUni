using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddLines
{
    class OddLines
    {
        static void Main(string[] args)
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
}
