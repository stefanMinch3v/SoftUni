using AutoMapper;

namespace AdvancedMapping
{
    public class Startup
    {
        public static void Main()
        {
            var managerSteve = new Employee()
            {
                FirstName = "Steve",
                LastName = "Jobbsen",
                Salary = 15000,
                Address = "Rugsvej 22",
                Subordinates = new System.Collections.Generic.HashSet<Employee>()
            };

            var employeeStephen = new Employee()
            {
                FirstName = "Stephen",
                LastName = "Bjorn",
                Salary = 4300,
                Address = "Boulevarden 22",
                Manager = managerSteve
            };

            var employeeKirilyc = new Employee()
            {
                FirstName = "Kirilyc",
                LastName = "Lefi",
                Salary = 4400,
                Address = "Strandja 22",
                Manager = managerSteve
            };

            managerSteve.Subordinates.Add(employeeKirilyc);
            managerSteve.Subordinates.Add(employeeStephen);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, ManagerDto>()
                                    .ForMember(mangrDto => mangrDto.NumberOfSubordinates, opt => opt.MapFrom(e => e.Subordinates.Count));
            });

            //EmployeeDto emplDto1 = Mapper.Map<EmployeeDto>(employeeStephen);
            //EmployeeDto emplDto2 = Mapper.Map<EmployeeDto>(employeeKirilyc);

            ManagerDto managerDto = Mapper.Map<ManagerDto>(managerSteve);

            System.Console.WriteLine($"{managerDto.FirstName} {managerDto.LastName}: {managerDto.NumberOfSubordinates}");
            foreach (var item in managerDto.Subordinates)
            {
                System.Console.WriteLine($"     -{item.FirstName} {item.LastName} {item.Salary}");
            }
        }
    }
}
