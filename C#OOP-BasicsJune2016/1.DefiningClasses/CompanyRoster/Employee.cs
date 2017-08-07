public class Employee
{

    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public Employee(string name, decimal salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        email = "n/a";
        age = -1;
    }

    public Employee(string name, decimal salary, string position, string department, string email)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = email;
        age = -1;
    }

    public Employee(string name, decimal salary, string position, string department, int age)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.age = age;
        email = "n/a";
    }

    public Employee(string name, decimal salary, string position, string department, string email, int age)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = email;
        this.age = age;
    }

    public string Name
    {
        get { return this.name; }
    }

    public decimal Salary => this.salary;

    public string Position
    {
        get { return this.position; }
    }

    public string Department => this.department;

    public string Email => this.email;

    public int Age
    {
        get { return this.age; }
    }
}
