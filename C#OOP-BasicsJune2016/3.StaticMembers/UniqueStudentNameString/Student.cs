using System.Collections.Generic;

class Student
{
    public static HashSet<string> uniqueNames;
    private string name;

    public Student(string name)
    {
        this.name = name;
    }

    static Student()
    {
        uniqueNames = new HashSet<string>();
    }
}
