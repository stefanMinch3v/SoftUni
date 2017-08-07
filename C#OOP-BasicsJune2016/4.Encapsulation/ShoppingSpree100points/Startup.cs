using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        Dictionary<string, Person> people = new Dictionary<string, Person>();
        Dictionary<string, Product> products = new Dictionary<string, Product>();

        string[] peopleInput = Console.ReadLine().Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
        CreateEntity(peopleInput, people);

        string[] productsInput = Console.ReadLine().Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
        CreateEntity(productsInput, products);

        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] commandLine = input.Split(new char[] {' '});
            string personName = commandLine[0];
            string productName = commandLine[1];

            Person person = people[personName];
            Product product = products[productName];

            try
            {
                person.BuyProduct(product);
                Console.WriteLine($"{personName} bought {productName}");
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }

            input = Console.ReadLine();
        }

        foreach (var person in people.Values)
        {
            Console.WriteLine(person);
        }
    }
    static void CreateEntity<T>(string[] tokens, Dictionary<string, T> collection)
    {
        for (int i = 0; i < tokens.Length; i += 2)
        {
            string name = tokens[i];
            decimal money = decimal.Parse(tokens[i + 1]);
            try
            {
                T item = (T)Activator.CreateInstance(typeof(T), new object[] { name, money });
                collection.Add(name, item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);// invoke our own created exception , otherwise it will trown Reflection's method exception which is built in and we cannot handle with it
                Environment.Exit(0);
            }

        }
    }
}

public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        products = new List<Product>();
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

    public void BuyProduct(Product product)
    {
        if (product.Money > this.Money)
        {
            throw new InvalidOperationException($"{this.name} can't afford {product.Name}");
        }
        this.money -= product.Money;
        this.products.Add(product);
    }

    public override string ToString()
    {
        string allProducts = string.Join(", ", products);
        return string.IsNullOrEmpty(allProducts) ? $"{name} - Nothing bought" : $"{name} - {allProducts}";
    }
}

public class Product
{
    private string name;
    private decimal cost;

    public Product(string name, decimal cost)
    {
        Name = name;
        Money = cost;
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
    public decimal Money
    {
        get
        {
            return this.cost;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(this.Money)} cannot be negative");
            }
            this.cost = value;
        }
    }
    public override string ToString()
    {
        return this.name;
    }
}

