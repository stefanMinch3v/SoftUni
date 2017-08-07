public class Person
{
    public Person()
    {
        name = "No name";
        age = 1;
    }

    public Person(int age)
    {
        name = "No name";
        this.age = age;
    }

    public Person(string name, int age)
        :this(age)
    {
        this.name = name;
    }

    public string name;
    public int age;
}

