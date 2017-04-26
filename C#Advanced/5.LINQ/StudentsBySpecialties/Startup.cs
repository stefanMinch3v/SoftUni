using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        List<Student> students = new List<Student>();
        List<StudentSpecialties> specialties = new List<StudentSpecialties>();

        while (! input.Contains("Students:"))
        {
            string specialtyPart = input[0];
            string specialtyTwo = input[1];
            int facultyNum = int.Parse(input[2]);

            specialties.Add(new StudentSpecialties(specialtyPart, specialtyTwo, facultyNum));
            //specialties.Clear();

            input = Console.ReadLine().Split();
        }

        input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        while (! input.Contains("END"))
        {
            int facultyNum = int.Parse(input[0]);
            string firstName = input[1];
            string lastName = input[2];

            students.Add(new Student(firstName, lastName, facultyNum));
            //students.Clear();

            input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        var joinStudents = students.Join(
                                        specialties,
                                        s => s.facultyId,
                                        spec => spec.facultyNumber, 
                                        (s, spec) => new
                                        {
                                            studentName = s.firstName + " " + s.lastName,
                                            facultyNumber = s.facultyId,
                                            courseName = spec.specialtyPart + " " + spec.specialtyPartTwo
                                        });
        //second way with sql syntax
        //var joinStudents = from s in students
        //                    join spec in specialties
        //                    on s.facultyId equals spec.facultyNumber
        //                    select new
        //                    {
        //                        studentName = s.firstName + " " + s.lastName,
        //                        facultyNumber = s.facultyId,
        //                        courseName = spec.specialtyPart + " " + spec.specialtyPartTwo
        //                    };

        foreach (var item in joinStudents.OrderBy(x => x.studentName))
        {
            Console.WriteLine($"{item.studentName} {item.facultyNumber} {item.courseName}");
        }

    }
}

public class StudentSpecialties
{
    public string specialtyPart { get; set; }

    public string specialtyPartTwo { get; set; }

    public int facultyNumber { get; set; }

    public StudentSpecialties(string sPart, string sPartTwo, int fNumber)
    {
        this.specialtyPart = sPart;
        this.specialtyPartTwo = sPartTwo;
        this.facultyNumber = fNumber;
    }
}

public class Student
{
    public string firstName { get; set; }

    public string lastName { get; set; }

    public int facultyId { get; set; }

    public Student(string fName, string lName, int fId)
    {
        this.firstName = fName;
        this.lastName = lName;
        this.facultyId = fId;
    }
}
