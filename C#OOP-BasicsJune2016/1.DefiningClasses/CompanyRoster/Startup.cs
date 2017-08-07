using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        List<Employee> employee = new List<Employee>();
        int rows = int.Parse(Console.ReadLine());
        string name = string.Empty;
        decimal salary = 0m;
        string position = string.Empty;
        string department = string.Empty;
        string email = string.Empty;
        int age = 0;

        for (int i = 0; i < rows; i++)
        {
            string[] commandLine = Console.ReadLine().Split();
            if (commandLine.Length == 4)
            {
                TakeInfo(name, salary, position, department, commandLine, employee);
                
            }
            else if (commandLine.Length == 5)
            {
                TakeInfo2(name, salary, position, department, email, age, commandLine, employee);   
            }
            else
            {
                TakeInfo3(name, salary, position, department, email, age, commandLine, employee);
            } 
        }
        PrintInfo(employee);
    }

    private static void PrintInfo(List<Employee> employee)
    {
        var result = employee
                                .GroupBy(e => e.Department)
                                .Select(e => new
                                {
                                    Departmentss = e.Key,
                                    AverageSalary = e.Average(emp => emp.Salary),
                                    Employees = e.OrderByDescending(emp =>  emp.Salary)
                                })
                                .FirstOrDefault();
        Console.WriteLine($"Highest Average Salary: {result.Departmentss}");

        foreach (var empl in result.Employees)
        {
            Console.WriteLine($"{empl.Name} {empl.Salary:F2} {empl.Email} {empl.Age}");
        }
    }

    private static void TakeInfo2(string name, decimal salary, string position, string department, string email, int age, string[] commandLine, List<Employee> employee)
    {
        name = commandLine[0];
        salary = decimal.Parse(commandLine[1]);
        position = commandLine[2];
        department = commandLine[3];

        int ages;
        bool isInteger = int.TryParse(commandLine[4], out ages);

        if (isInteger)
        {
            age = int.Parse(commandLine[4]);
            var emply = new Employee(name, salary, position, department, age);
            employee.Add(emply);
        }
        else
        {
            email = commandLine[4];
            var emply = new Employee(name, salary, position, department, email);
            employee.Add(emply);
        }
    }

    private static void TakeInfo(string name, decimal salary, string position, string department, string[] commandLine, List<Employee> employee)
    {
        name = commandLine[0];
        salary = decimal.Parse(commandLine[1]);
        position = commandLine[2];
        department = commandLine[3];
        var emply = new Employee(name, salary, position, department);
        employee.Add(emply);
    }

    private static void TakeInfo3(string name, decimal salary, string position, string department, string email, int age, string[] commandLine, List<Employee> employee)
    {
        name = commandLine[0];
        salary = decimal.Parse(commandLine[1]);
        position = commandLine[2];
        department = commandLine[3];
        email = commandLine[4];
        age = int.Parse(commandLine[5]);
        var emply = new Employee(name, salary, position, department, email, age);
        employee.Add(emply);
    }

}
