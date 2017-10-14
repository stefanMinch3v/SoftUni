namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using SoftUni.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var context = new SoftUniContext();

            //17
            //CallStoredProcedure(context);

            //18
            //EmployeesMaximumSalaries(context);
        }

        private static void EmployeesMaximumSalaries(SoftUniContext context)
        {
            var result = context.Departments.ToArray();
            foreach (var dep in result)
            {
                decimal maxSalary = dep.Employees.Max(e => e.Salary);
                if (!(maxSalary > 30000 && maxSalary < 70000))
                {
                    Console.WriteLine($"{dep.Name} - {maxSalary}");
                }
            }
        }

        private static void CallStoredProcedure(SoftUniContext context)
        {
            string[] input = Console.ReadLine().Split();
            string firstName = input[0];
            string lastName = input[1];

            var result = context.Database.SqlQuery<ProjectViewModel>("EXEC dbo.usp_GetProjectsByEmployee {0}, {1}", firstName, lastName);// create an additional view model to take only the neccessary information otherwise it takes all the info which is redundant
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - {item.Description}, {item.StartDate}");
            }
        }
    }
}
