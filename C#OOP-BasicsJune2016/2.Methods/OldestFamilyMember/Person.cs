using System;

public class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public int GetAge => this.age;
    public string GetName => this.name;
}