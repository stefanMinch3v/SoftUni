using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LadyBugs
{
    public static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        int[] saveBugs = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] bugs = new int[num];

        for (int i = 0; i < bugs.Length; i++)
        {
            if (saveBugs.Contains(i))
            {
                bugs[i] = 1;
            }
            else
            {
                bugs[i] = 0;
            }
        }

        string input = Console.ReadLine();
        while (!input.Equals("end"))
        {
            string[] command = input.Split();
            int firstIndex = int.Parse(command[0]);
            int secondIndex = int.Parse(command[2]);

            switch (command[1])
            {
                case "right"://when is positive goes right and when is negative goes left 
                    if (bugs[secondIndex] == 1 || bugs[secondIndex + 1] == 1)
                    {
                        if (bugs[secondIndex+1] == 1 || bugs[secondIndex+1] > bugs.Length)
                        {
                            bugs[firstIndex] = 0;
                        }
                        else
                        {
                            bugs[secondIndex + 1] = 1;
                            bugs[firstIndex] = 0;
                        }
                    }
                    else if(bugs[secondIndex] == 0)
                    {
                        bugs[secondIndex] = 1;
                        bugs[firstIndex] = 0;
                    }
                    break;
                case "left":// when is positive goes left and when is negative goes right
                    if (bugs[firstIndex - secondIndex] == 1)
                    {
                        if (bugs[firstIndex - secondIndex] == 1 || bugs[firstIndex - secondIndex] < bugs.Length)
                        {
                            bugs[firstIndex] = 0;
                        }
                        else
                        {
                            bugs[firstIndex - secondIndex] = 1;
                            bugs[firstIndex] = 0;
                        }
                    }
                    else if(bugs[firstIndex - secondIndex] == 0)
                    {
                        bugs[firstIndex - secondIndex] = 1;
                        bugs[firstIndex] = 0;
                    }

                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(string.Join(" ", bugs));
        //unfortunately 10 percent in judge
    }
}
