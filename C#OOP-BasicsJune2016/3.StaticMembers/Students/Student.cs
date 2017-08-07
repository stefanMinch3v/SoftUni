public class Student
{
    public static int countStudents = 0;
    private string name;

    public Student(string name)
    {
        countStudents++;
        this.name = name;
    }
}
