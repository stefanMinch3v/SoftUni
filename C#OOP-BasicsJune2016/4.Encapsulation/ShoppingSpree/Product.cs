﻿using System;

public class Product
{
    private string name;
    private decimal cost;

    public Product(string name, decimal cost)
    {
        Name = name;
        Cost = cost;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{nameof(this.Name)} cannot be empty");
            }
            this.name = value;
        }
    }
    public decimal Cost
    {
        get
        {
            return this.cost;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(this.Cost)} cannot be negative");
            }
            this.cost = value;
        }
    }
}