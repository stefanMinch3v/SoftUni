using System;

public class Parent
{
    private string name;
    private string birthday;

    public Parent(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }

    public string GetDetails()
    {
        return $"{name} {birthday}";
    }
}
