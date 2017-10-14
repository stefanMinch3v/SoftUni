namespace ProjectionSolution
{
    using AutoMapper;
    using ProjectionSolution.Data;
    using ProjectionSolution.Models;
    using System;
    using System.Linq;
    using AutoMapper.QueryableExtensions;

    public class Startup
    {
        public static void Main()
        {
            //SeedData();
            Mapper.Initialize(a => a.CreateMap<Employee, EmployeeDto>());

            using (var context = new EmployeeContext())
            {
                var employees = context.Employees
                                                .Where(emp => emp.Birthday.Value.Year < 1990)
                                                .OrderByDescending(emp => emp.Salary)
                                                .ProjectTo<EmployeeDto>()
                                                .ToList();

                foreach (var empl in employees)
                {
                    Console.WriteLine(empl);
                }               

            }
        }

        private static void SeedData()
        {
            using (var context = new EmployeeContext())
            {
                //context.Database.Initialize(true);
                var managerSteve = new Employee()
                {
                    FirstName = "Steve",
                    LastName = "Jobbsen",
                    Salary = 15000,
                    Address = "Rugsvej 22",
                    Birthday = DateTime.Parse("01-01-1978")
                };

                var employeeStephen = new Employee()
                {
                    FirstName = "Stephen",
                    LastName = "Bjorn",
                    Salary = 4300,
                    Address = "Boulevarden 22",
                    Manager = managerSteve,
                    Birthday = DateTime.Parse("01-01-1988")

                };

                var employeeKirilyc = new Employee()
                {
                    FirstName = "Kirilyc",
                    LastName = "Lefi",
                    Salary = 4400,
                    Address = "Strandja 22",
                    Manager = managerSteve,
                    Birthday = DateTime.Parse("01-01-1991")
                };

                context.Employees.Add(managerSteve);
                context.Employees.Add(employeeKirilyc);
                context.Employees.Add(employeeStephen);
                context.SaveChanges();
            }
            
            
        }
    }
}
