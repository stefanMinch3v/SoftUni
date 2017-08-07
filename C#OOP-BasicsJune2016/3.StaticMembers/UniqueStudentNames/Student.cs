using System;
using System.Collections.Generic;

public class Student
{
    public static HashSet<Student> uniqueStudents;
    private string name;
    
    public Student(string name)
    {
        this.name = name;
    }

    static Student()
    {
        uniqueStudents = new HashSet<Student>();
    }

    public override bool Equals(object other)
    {
        return this.GetHashCode().Equals(other.GetHashCode());
    }

    public override int GetHashCode()
    {
        return this.name.GetHashCode();
    }
}
