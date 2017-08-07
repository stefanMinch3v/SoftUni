using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{nameof(this.Name)} cannot be empty");
            }
            this.name = value;
        }
    }
    public decimal Money
    {
        get
        {
            return this.money;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(this.Money)} cannot be negative");
            }
            this.money = value;
        }
    }
    public decimal BuyProduct(decimal cost)
    {
        return this.money >= cost ? this.money -= cost : -1;
    }
}
