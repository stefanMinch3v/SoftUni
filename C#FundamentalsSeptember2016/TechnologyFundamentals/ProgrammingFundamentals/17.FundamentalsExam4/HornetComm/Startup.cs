using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        List<string> broadcasts = new List<string>();
        List<string> privateMessages = new List<string>();

        string input = Console.ReadLine();
        while (!input.Equals("Hornet is Green"))
        {
            string[] commandLine = input.Split();
            if (commandLine.Length > 3 || !commandLine[1].Equals("<->"))
            {
                goto end;
            }
            decimal temp;
            bool isPrivate = decimal.TryParse(commandLine[0], out temp);

            if (isPrivate)
            {
                char[] reverseRecipient = commandLine[0].ToCharArray();
                Array.Reverse(reverseRecipient);
                string recipient = string.Join("", reverseRecipient);
                string message = commandLine[2];
                bool hasSymbol = false;

                for (int i = 0; i < message.Length; i++)
                {
                    if (!char.IsLetterOrDigit(message[i]))
                    {
                        hasSymbol = true;
                        break;
                    }
                }

                if (!hasSymbol)
                {
                    privateMessages.Add(recipient + " -> " + message);
                }

            }
            else
            {
                bool hasSymbol = false;
                string message = commandLine[0];
                string formatFrequency = commandLine[2];
                string frequency = string.Empty;

                for (int i = 0; i < formatFrequency.Length; i++)
                {
                    if (!char.IsLetterOrDigit(formatFrequency[i]))
                    {
                        hasSymbol = true;
                        break;
                    }
                }

                if (!hasSymbol)
                {
                    for (int i = 0; i < formatFrequency.Length; i++)
                    {
                        char currentChar = formatFrequency[i];
                        if (char.IsLetter(currentChar) && char.IsLower(currentChar))
                        {
                            frequency += char.ToUpper(formatFrequency[i]);
                        }
                        else if (char.IsLetter(currentChar) && char.IsUpper(currentChar))
                        {
                            frequency += char.ToLower(formatFrequency[i]);
                        }
                        else
                        {
                            frequency += currentChar;
                        }
                    }
                    broadcasts.Add(frequency + " -> " + message);
                }                
            }

            end:
            input = Console.ReadLine();
        }
        
        

        int lengthBroadcasts = broadcasts.Count;
        switch (lengthBroadcasts)
        {
            case 0:
                Console.WriteLine("Broadcasts:");
                Console.WriteLine("None");
                break;
            default:
                Console.WriteLine("Broadcasts:");
                foreach (var message in broadcasts)
                {
                    Console.WriteLine(message);
                }
                break;
        }

        int lengthPrivate = privateMessages.Count;
        switch (lengthPrivate)
        {
            case 0:
                Console.WriteLine("Messages:");
                Console.WriteLine("None");
                break;
            default:
                Console.WriteLine("Messages:");
                foreach (var message in privateMessages)
                {
                    Console.WriteLine(message);
                }
                break;
        }
    }
}
