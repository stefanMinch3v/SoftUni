using System;

public class Company
{
    private string companyName;
    private string department;
    private decimal salary;

    public Company(string companyName, string department, decimal salary)
    {
        this.companyName = companyName;
        this.department = department;
        this.salary = salary;
    }

    public string GetDetails()
    {
        return $"{companyName} {department} {salary:F2}";
    }
}
