using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UsernamesExercise
{
    public static void Main(string[] args)
    {
        HashSet<string> usernames = new HashSet<string>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            usernames.Add(Console.ReadLine());
        }

        Console.WriteLine(string.Join("\n", usernames));
    }
}
