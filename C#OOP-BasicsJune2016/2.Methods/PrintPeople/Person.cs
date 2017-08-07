public class Person
{
    private string name;
    private int age;
    private string occupation;

    public Person(string name, int age, string occupation)
    {
        this.name = name;
        this.age = age;
        this.occupation = occupation;
    }
    public string GetName => this.name;
    public int GetAge => this.age;
    public string GetOccupation => this.occupation;

    override public string ToString()
    {
        return $"{name} - age: {age}, occupation: {occupation}";
    }
}
