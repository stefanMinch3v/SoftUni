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
        GetFiles("TestFolder"); // print out recursivly all files and folders 
    }
    public static void GetFiles(string directory)
    {
        if (Directory.Exists(directory))
        {
            Console.WriteLine($"---{directory}---");

            string[] allFiles = Directory.GetFiles(directory);
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };

            foreach (var file in allFiles)
            {
                double len = new FileInfo(file).Length;
                int counter = 0;
                while (len >= 1024 && counter < sizes.Length - 1)
                {
                    counter++;
                    len = len / 1024;
                    Console.WriteLine(len);
                }

            }
            //rec
            //string[] allDirs = Directory.GetDirectories(directory);

            //foreach (var dir in allDirs)
            //{
            //    GetFiles(dir);
            //}
        }
        else
        {
            Console.WriteLine("No such directory!!");
        }
    }
}
