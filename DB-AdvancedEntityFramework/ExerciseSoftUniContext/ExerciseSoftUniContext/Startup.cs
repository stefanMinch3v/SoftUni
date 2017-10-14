namespace ExerciseSoftUniContext
{
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public class Startup
    {
        public static void Main()
        {
            var entity = new SoftUniEntities();
            var employee = entity.Employees.Where(e => e.DepartmentID == 5).Select(e => e.EmployeeID + "." + e.FirstName + " " + e.LastName);
            //Console.WriteLine(string.Join(", \n", employee));
            //Console.WriteLine(employee);
            //var town = new Town()
            //{
            //    Name = "Gramatikovo"
            //};

            //entity.Towns.Add(town);
            //entity.SaveChanges();

            //var allTowns = entity.Towns.Select(t => t.Name).OrderBy(x => x).ToList();
            //Console.WriteLine(string.Join(Environment.NewLine, allTowns));

            //var keyPressed = Console.ReadKey();
            //Console.WriteLine(keyPressed.Key);

            ListAllProjects(entity);
        }

        private static void ListAllProjects(SoftUniEntities entity)
        {
            int pageSize = 14;
            var projects = entity.Projects.ToList();
            int page = 0;
            int maxPages = (int)Math.Ceiling(projects.Count / (double)pageSize);
            int pointer = 1;

            while (true)
            {
                ChangeConsoleColorToBlackAndWhite();
                Console.Clear();
                Console.WriteLine($"  ID | Project Name (Page {page + 1} out of {maxPages})");
                Console.WriteLine("-----+---------------------------------------");

                int current = 1;

                foreach (var proj in projects.Skip(page * pageSize).Take(pageSize))
                {
                    ChangeConsoleColorToBlackAndWhite();

                    if (current == pointer)
                    {
                        ChangeConsoleColorToWhiteAndBlack();
                    }

                    Console.WriteLine($"{proj.ProjectID,4}| {proj.Name}");
                    current++;
                }

                var key = Console.ReadKey();
                switch (key.Key.ToString())
                {
                    case "UpArrow":
                        if (pointer > 1)
                        {
                            pointer--;
                        }
                        else if (page > 0)
                        {
                            page--;
                            pointer = pageSize;
                        }

                        break;
                    case "DownArrow":
                        if (pointer < pageSize)
                        {
                            pointer++;
                        }
                        else if (page + 1 < maxPages)
                        {
                            page++;
                            pointer = 1;
                        }

                        break;
                    case "Escape":
                        Console.WriteLine();
                        Console.WriteLine("Program stopped!");
                        Environment.Exit(0);

                        break;
                    case "Enter":
                        var currentProject = projects.Skip(pageSize * page + pointer - 1).First();
                        ShowDetails(currentProject);

                        break;
                }

            }
        }

        private static void ChangeConsoleColorToBlackAndWhite()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void ChangeConsoleColorToWhiteAndBlack()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        private static void ShowDetails(Project project)
        {
            Console.Clear();
            Console.WriteLine($"ID: {project.ProjectID, -4}|  {project.Name}");
            Utility.PrintHorizontalLine();
            Console.WriteLine($"Description:\n{project.Description}");
            Utility.PrintHorizontalLine();
            Console.WriteLine($"Start date: {project.StartDate} - End date: {project.EndDate}");
            Utility.PrintHorizontalLine();
            var employees = project.Employees.ToList();
            Console.WriteLine(string.Join("\n", employees.Select(e => e.FirstName + " " + e.LastName)));
            Console.ReadKey();
        }


    }
}
