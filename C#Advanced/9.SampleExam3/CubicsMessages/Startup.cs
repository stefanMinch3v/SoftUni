using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        List<string> decodedMessages = new List<string>();
        string input = Console.ReadLine();

        Regex regex = new Regex(@"^([0-9]+)([a-zA-Z]+)([^a-zA-Z]*)$");

        while (input != "Over!")
        {
            string firstLine = input;
            int secondLine = int.Parse(Console.ReadLine());

            if (regex.IsMatch(firstLine))
            {
                StringBuilder verification = new StringBuilder();

                Match match = regex.Match(firstLine);

                string message = match.Groups[2].Value;

                if (message.Length != secondLine)
                {
                    goto end;
                }

                string numbers = match.Groups[1].Value + match.Groups[3].Value;

                foreach (var character in numbers)
                {
                    if (char.IsDigit(character))
                    {
                        int index = int.Parse(character.ToString());
                        if (index >= message.Length)
                        {
                            verification.Append(" ");
                        }
                        else
                        {
                            verification.Append(message[index]);
                        }
                    }
                    else
                    {
                        verification.Append(" ");
                    }
                }
                decodedMessages.Add($"{message} == {verification.ToString()}");
            }

            end: input = Console.ReadLine();
        }

        foreach (var item in decodedMessages)
        {
            Console.WriteLine(item);
        }
        
    }
}
