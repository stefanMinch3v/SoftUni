namespace AllExercisesExtractInMethods
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            //using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            //{
            //    Console.SetOut(writer);
            //    foreach (var address in addressess)
            //    {
            //        Console.WriteLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
            //    }
            //}

            var entity = new SoftUniContext(); // better way is to put this in using block
            var gringottsEntity = new GringottsContext();
            //var result = entity.Employees.Where(x => x.FirstName.Contains("L")); // if there is 'select' and includes the format with $"{} {}" recognize it exactly as if sql format and can put all sql commands in it!!!!

            //task3
            //EmployeesFullInformation(entity);

            //task4
            //EmployeesWithSalaryOver50000(entity);

            //task5
            //EmployeesFromSeattle(entity);

            //task6
            //AddingNewAddressAndUpdatingEmployee(entity);

            //task7
            //FindEmployeesPeriod(entity);//

            //task8
            //AddressesByTownName(entity);

            //task9
            //EmployeeWithId147(entity);

            //task10
            DepartmentsWithMoreThan5Employees(entity);

            //task11
            //FindLastest10Projects(entity);

            //task12
            //IncreaseSalaries(entity);

            //task13
            //FindEmployeesByFirstNameStartsWithSa(entity);

            //task14
            //GringottsFirstLetter(gringottsEntity);

            //task15
            //DeleteProjectById(entity);

            //task16
            //RemoveTowns(entity);

            //task17
            CompareNativeWithLinqSqlQueries(entity);
        }

        private static void CompareNativeWithLinqSqlQueries(SoftUniContext entity)
        {
            Stopwatch sw = new Stopwatch();
            //entity.Addresses.Count(); // use this once to open the entity connection it improves the speed much more !!
            //linq query
            sw.Start();
            Console.WriteLine(entity.Projects.Where(p => p.StartDate.Year > 2000).Count());
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            sw.Reset();

            Console.WriteLine("--------------");

            //native query
            sw.Start();
            Console.WriteLine(entity.Database.SqlQuery<int>("SELECT COUNT(*) FROM Projects WHERE  YEAR(StartDate) > 2000").First());
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        private static void RemoveTowns(SoftUniContext entity)
        {
            var town = Console.ReadLine();
            int countDeletedAddresses = 0;

            entity.Database.BeginTransaction();

            var employees = entity.Employees.Where(x => x.Address.Town.Name == town);
            if (employees != null)
            {
                foreach (var empl in employees)
                {
                    empl.AddressID = null;
                }

                entity.SaveChanges();

                int idToDelete = entity.Towns.FirstOrDefault(x => x.Name == town)?.TownID ?? -1;

                if (idToDelete == -1)
                {
                    Console.WriteLine("No such city!");
                    entity.Database.CurrentTransaction.Rollback();
                    return;
                }

                var addresses = entity.Addresses.Where(x => x.TownID == idToDelete);

                foreach (var address in addresses)
                {
                    address.TownID = null;
                    countDeletedAddresses++;
                }
            }

            Console.WriteLine($"{town} {countDeletedAddresses} address in {town} were deleted");
            entity.Database.CurrentTransaction.Rollback();
        }

        private static void DeleteProjectById(SoftUniContext entity)
        {
            using (entity.Database.BeginTransaction())
            {
                var project = entity.Projects.FirstOrDefault(p => p.ProjectID == 2);

                foreach (var empl in project.Employees)
                {
                    empl.Projects.Remove(project);
                }

                entity.Projects.Remove(project);
                entity.SaveChanges();

                var desiredProjects = entity.Projects.Take(10).ToList();
                desiredProjects.ForEach(p => Console.WriteLine(p.Name));

                entity.Database.CurrentTransaction.Rollback();
            }  
        }

        private static void GringottsFirstLetter(GringottsContext gringottsEntity)
        {
            var wizzards = gringottsEntity.WizzardDeposits.Where(w => w.DepositGroup == "Troll Chest")
                                                                      .Select(w => w.FirstName.Substring(0, 1))
                                                                      .Distinct();

            foreach (var wizzard in wizzards.OrderBy(w => w))
            {
                Console.WriteLine(wizzard);
            }
        }

        private static void FindEmployeesByFirstNameStartsWithSa(SoftUniContext entity)
        {
            var employees = entity.Employees.Where(e => e.FirstName.StartsWith("Sa"));

            foreach (var empl in employees)
            {
                Console.WriteLine($"{empl.FirstName} {empl.LastName} - {empl.JobTitle} - (${empl.Salary})");
            }
        }

        private static void IncreaseSalaries(SoftUniContext entity)
        {
            string[] departmentsToIncrease = { "Engineering", "Tool Design", "Marketing", "Information Services" };
            var employees = entity.Employees.Where(e => departmentsToIncrease.Contains(e.Department.Name));

            foreach (var empl in employees)
            {
                empl.Salary *= 1.12m;
                Console.WriteLine($"{empl.FirstName} {empl.LastName} (${empl.Salary})");
            }

            entity.SaveChanges();
        }

        private static void FindLastest10Projects(SoftUniContext entity)
        {
            var projects = entity.Projects.OrderByDescending(d => d.StartDate)
                                                      .Take(10);
            foreach (var project in projects.OrderBy(p => p.Name))
            {
                Console.Write($"{project.Name} {project.Description} {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.DefaultThreadCurrentCulture)}");
                if (project.EndDate.HasValue)
                {
                    Console.WriteLine($" {project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.DefaultThreadCurrentCulture)}");
                }

                Console.WriteLine();
            }
        }

        private static void DepartmentsWithMoreThan5Employees(SoftUniContext entity)
        {
            var departments = entity.Departments.Where(d => d.Employees.Count > 5)
                                                            .OrderBy(e => e.Employees.Count);
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Name} {department.Employee.FirstName}"); // Employee is Manager in this case it needs to refactor the name in entity properties
                foreach (var empl in department.Employees)
                {
                    Console.WriteLine($"{empl.FirstName} {empl.LastName} {empl.JobTitle}");
                }
            }
        }

        private static void EmployeeWithId147(SoftUniContext entity)
        {
            var employee = entity.Employees.Where(e => e.EmployeeID == 147);
            foreach (var empl in employee)
            {
                Console.WriteLine($"{empl.FirstName} {empl.LastName} {empl.JobTitle}");
                foreach (var projects in empl.Projects.OrderBy(p => p.Name))
                {
                    Console.WriteLine(projects.Name);
                }
            }
        }

        private static void AddressesByTownName(SoftUniContext entity)
        {
            var addresses = entity.Addresses.OrderByDescending(e => e.Employees.Count)
                                                       .ThenBy(t => t.Town.Name)
                                                       .Take(10);
            foreach (var address in addresses)
            {
                Console.WriteLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
            }
        }

        private static void FindEmployeesPeriod(SoftUniContext entity)
        {
            DateTime startDate = DateTime.Parse("2001.01.01");
            DateTime endDate = DateTime.Parse("2003.01.01");

            var employees = entity.Employees.Where(e => e.Projects.Any(p => p.StartDate >= startDate && p.StartDate <= endDate))
                                            .Take(30)
                                            .Select(e => new { e.FirstName, e.LastName, managerName = e.Manager.FirstName, e.Projects });

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.managerName}");

                foreach (var project in employee.Projects)
                {
                    Console.Write($"--{project.Name} {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.DefaultThreadCurrentCulture)}");
                    if (project.EndDate.HasValue)
                    {
                        Console.WriteLine($" {project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.DefaultThreadCurrentCulture)}");
                    }
                    else
                    {
                        Console.WriteLine();
                    }

                }
            }
        }

        private static void AddingNewAddressAndUpdatingEmployee(SoftUniContext entity)
        {
            var address = new Address()
            {
                AddressID = 4,
                AddressText = "Vitoshka 15"
            };

            Employee nakov = entity.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            nakov.Address = address;
            entity.SaveChanges();

            var top10EmployeesOrderByDescending = entity.Employees.OrderByDescending(x => x.AddressID)
                                                                  .Take(10).Select(x => x.Address.AddressText)
                                                                  .ToList();
            Console.WriteLine(string.Join(Environment.NewLine, top10EmployeesOrderByDescending));
        }

        private static void EmployeesFromSeattle(SoftUniContext entity)
        {
            var employees = entity.Employees.ToList();
            var resultCollection = employees.Where(e => e.Department.Name == "Research and Development")
                                            .OrderBy(e => e.Salary)
                                            .ThenByDescending(e => e.FirstName)
                                            .Select(e => $"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:F2}");
            Console.WriteLine(string.Join(Environment.NewLine, resultCollection));
        }

        private static void EmployeesWithSalaryOver50000(SoftUniContext entity)
        {
            var employees = entity.Employees.ToList();
            var resultCollection = employees.Where(e => e.Salary > 50000).Select(e => e.FirstName);
            Console.WriteLine(string.Join(Environment.NewLine, resultCollection));
        }

        private static void EmployeesFullInformation(SoftUniContext entity)
        {
            var projects = entity.Employees.ToList();
            var resultCollection = projects.OrderBy(e => e.EmployeeID)
                                             .Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary}");

            Console.WriteLine(string.Join(Environment.NewLine, resultCollection));
        }
    }
}
