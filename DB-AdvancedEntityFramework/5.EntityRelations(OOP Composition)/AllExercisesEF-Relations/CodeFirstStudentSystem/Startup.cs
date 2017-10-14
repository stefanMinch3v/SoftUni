namespace CodeFirstStudentSystem
{
    using CodeFirstStudentSystem.Data;
    using System.Linq;
    using System;
    using System.Globalization;

    public class Startup
    {
        public static void Main()
        {
            var context = new StudentContext();
            //context.Database.Initialize(true);

            //PrintAllStudentsAndHomeworks(context);
            //PrintAllCoursesAndResources(context);
            //CoursesWithMoreThanFiveResources(context);
            //CoursesWithGivenDate(context);
            //StudentsAndNumberOfCourses(context);
        }

        private static void StudentsAndNumberOfCourses(StudentContext context)
        {
            foreach (var student in context.Students
                                                                .OrderByDescending(s => s.Courses.Sum(c => c.Price))
                                                                .ThenByDescending(s => s.Courses.Count)
                                                                .ThenBy(s => s.Name))
            {
                Console.WriteLine($"{student.Name} - {student.Courses.Count} - Total price: {student.Courses.Sum(c => c.Price)} Average price: {student.Courses.Average(c => c.Price)}");
            }
        }

        private static void CoursesWithGivenDate(StudentContext context)
        {
            DateTime date = new DateTime(2017, 08, 08);
            var difference = context.Courses.Select(c => int.Parse((c.StartDate - c.EndDate).TotalDays.ToString().Substring(1, 2))).ToArray();
            var courses = context.Courses.Where(c => c.StartDate >= date);
            foreach (var course in courses.OrderByDescending(s => s.Students.Count))
            {
                Console.WriteLine($"{course.Name} - Start:{course.StartDate} - End:{course.EndDate} : Days:{(course.StartDate - course.EndDate).TotalDays.ToString().Substring(1, 2)}, number of st enrolled: {course.Students.Count}");
            }
        }

        private static void CoursesWithMoreThanFiveResources(StudentContext context)
        {
            var courses = context.Courses
                                                    .Where(c => c.Resources.Count > 5)
                                                    .OrderByDescending(r => r.Resources.Count)
                                                    .ThenBy(c => c.StartDate);
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} - {course.Resources.Count}");
            }
        }

        private static void PrintAllCoursesAndResources(StudentContext context)
        {
            foreach (var course in context.Courses.OrderBy(c => c.StartDate).ThenByDescending(c => c.EndDate))
            {
                Console.WriteLine($"{course.Name} - {course.Description}:");
                foreach (var item in course.Resources)
                {
                    Console.WriteLine($"    -{item.Name} - {item.TypeOfResource} - {item.Url}");
                }
            }
        }

        private static void PrintAllStudentsAndHomeworks(StudentContext context)
        {
            var studentsAndHomeworks = context.Students.Where(s => s.Homework.Count > 0);
            foreach (var students in studentsAndHomeworks)
            {
                Console.WriteLine(students.Name);
                Console.Write("Homework: ");
                foreach (var home in students.Homework)
                {
                    Console.WriteLine($"{home.Content} - {home.ContentType}");
                }
            }
        }
    }
}
