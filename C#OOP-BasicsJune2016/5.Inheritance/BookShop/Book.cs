using System;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private double price;

    public Book(string author, string title, double price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    public string Author
    {
        get
        {
            return this.author;
        }
        protected set
        {
            if (value.Contains(" "))
            {
                int findIndex = value.IndexOf(' ');
                string secondName = value.Substring(findIndex);
                foreach (var sName in secondName)
                {
                    if (char.IsDigit(sName))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }
            }
            this.author = value;
        }
    }

    public string Title
    {
        get
        {
            return this.title;
        }
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }
    public virtual double Price
    {
        get
        {
            return this.price;
        }
        protected set
        {
            if (value < 1)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Type: {this.GetType().Name}{Environment.NewLine}Title: {this.Title}{Environment.NewLine}Author: {this.Author}{Environment.NewLine}Price: {this.Price:F1}");
        return sb.ToString();
    }
}

