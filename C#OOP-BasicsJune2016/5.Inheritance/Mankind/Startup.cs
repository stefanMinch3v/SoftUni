using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        string[] students = Console.ReadLine().Split();
        string[] workers = Console.ReadLine().Split();

        try
        {
            Student student = new Student(students[0], students[1], students[2]);
            Console.WriteLine(student);
            Console.WriteLine();
            Worker worker = new Worker(workers[0], workers[1], decimal.Parse(workers[2]), double.Parse(workers[3]));
            Console.WriteLine(worker);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        
    }
}
