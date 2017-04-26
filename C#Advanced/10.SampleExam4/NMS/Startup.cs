using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        List<string> results = new List<string>();
        string input = Console.ReadLine();

        while (input != "---NMS SEND---")
        {
            string[] commandLine = input.Split('\n');

            results.AddRange(commandLine);

            input = Console.ReadLine();
        }
        string delimiter = Console.ReadLine();

        string command = string.Join("", results);
        string compare = command.ToLower();

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < compare.Length - 1; i++)
        {
            if (compare[i] <= compare[i + 1])
            {
                sb.Append(command[i]);
            }
            else
            {
                sb.Append(command[i] + delimiter);
            }
        }
        sb.Append(command[command.Length - 1]);

        Console.WriteLine(string.Join("", sb));
    }
}
