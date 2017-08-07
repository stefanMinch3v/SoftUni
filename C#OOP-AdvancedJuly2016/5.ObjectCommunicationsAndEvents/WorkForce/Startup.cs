namespace WorkForce
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            ModifiedList jobs = new ModifiedList();
            Dictionary<string, Employee> employeesByName = new Dictionary<string, Employee>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                var commandLine = input.Split();
                switch (commandLine[0])
                {
                    case "StandartEmployee":
                        var standartEmployee = new StandartEmployee(commandLine[1]);
                        employeesByName[commandLine[1]] = standartEmployee;
                        break;
                    case "PartTimeEmployee":
                        var partTimeEmployee = new PartTimeEmployee(commandLine[1]);
                        employeesByName[commandLine[1]] = partTimeEmployee;
                        break;
                    case "Job":
                        var employee = employeesByName[commandLine[3]];
                        var job = new Job(employee, commandLine[1], int.Parse(commandLine[2]));
                        jobs.Add(job);
                        job.JobUpdater += jobs.JobHandlerCompletion;
                        break;
                    case "Pass":
                        List<Job> jobsToUpdate = new List<Job>(jobs);
                        foreach (var work in jobsToUpdate)
                        {
                            work.Update();
                        }
                        break;
                    case "Status":
                        foreach (var work in jobs)
                        {
                            Console.WriteLine(work);
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
