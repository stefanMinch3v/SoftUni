using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexOfLetters
{
    class IndexOfLetters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //char[] alphabetString = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            string[] alphabetString = File.ReadAllText("input.txt").Split(',').ToArray();
            char[] alphabetChar = new char[alphabetString.Length];

            for (int i = 0; i < alphabetString.Length; i++)
            {
                alphabetChar[i] = char.Parse(alphabetString[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < alphabetChar.Length; j++)
                {
                    if (input[i].Equals(alphabetChar[j]))
                    {

                        var result = alphabetChar[j] + " -> " + Array.IndexOf(alphabetChar, alphabetChar[j]);
                        File.AppendAllText("output.txt", result + "\r\n");
                    }
                }
            }
        }
    }
}
