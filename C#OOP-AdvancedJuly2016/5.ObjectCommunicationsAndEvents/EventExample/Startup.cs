namespace EventExample
{
    public class Startup
    {
        public static void Main()
        {
            var student = new Student
            {
                Name = "Ivan"
            };

            var anotherStudent = new Student
            {
                Name = "Gosho"
            };

            var thirdStudent = new Student
            {
                Name = "Pesho"
            };

            var teacher = new Teacher
            {
                Name = "G-n Ivanov"
            };

            student.AttendClass(teacher);
            anotherStudent.AttendClass(teacher);

            teacher.StartClass("Math");
        }
    }
}
