namespace SimpleMapping
{
    using System;
    using AutoMapper;

    public class Startup
    {
        public static void Main()
        {
            var employee = new Employee()
            {
                FirstName = "pesho",
                LastName = "peshev",
                Address = "Buzludja 5",
                Salary = 2500m,
                Birthday = DateTime.Parse("01-01-1988")
            };

            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>());
            EmployeeDto dto = Mapper.Map<EmployeeDto>(employee);
            Console.WriteLine(dto);
        }
    }
}
