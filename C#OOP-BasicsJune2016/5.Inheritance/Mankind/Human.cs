using System;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string fName, string lName)
    {
        FirstName = fName;
        LastName = lName;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        protected set
        {
            if (char.IsUpper(char.Parse(value.Substring(1,1))))
            {
                throw new ArgumentException("Expected upper case letter!Argument: firstName");
            }
            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols!Argument: firstName");
            }
            this.firstName = value;
        }
    }
    public virtual string LastName
    {
        get
        {
            return this.lastName;
        }
        protected set
        {
            if (char.IsUpper(char.Parse(value.Substring(1, 1))))
            {
                throw new ArgumentException("Expected upper case letter!Argument: lastName");
            }
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols!Argument: lastName");
            }
            this.lastName = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}\nLast Name: {this.LastName}";
    }
}
