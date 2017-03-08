using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AndreyAndBilliard
{
    public static void Main(string[] args)
    {
        Dictionary<string, decimal> shopMenu = new Dictionary<string, decimal>();
        int input = int.Parse(Console.ReadLine());
        List<Customer> allCustomerObjects = new List<Customer>();

        for (int i = 0; i < input; i++)
        {
            string[] commands = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            string entity = commands[0];
            decimal price = decimal.Parse(commands[1]);

            FillOutShopMenu(shopMenu, entity, price);
        }

        string chooseCustomer = Console.ReadLine();

        while (!chooseCustomer.Equals("end of clients"))
        {
            string[] customerInput = chooseCustomer.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string username = customerInput[0];
            string product = customerInput[1];
            int quantity = int.Parse(customerInput[2]);

            if (!shopMenu.ContainsKey(product))
            {
                chooseCustomer = Console.ReadLine();
                continue;
            }

            CreateAddCheckData(shopMenu, allCustomerObjects, username, product, quantity);

            chooseCustomer = Console.ReadLine();
        }

        PrintResults(allCustomerObjects);

    }

    private static void CreateAddCheckData(Dictionary<string, decimal> shopMenu, List<Customer> allCustomerObjects, string username, string product, int quantity)
    {
        if (allCustomerObjects.Any(cust => cust.Name.Equals(username)))
        {
            Customer customer = allCustomerObjects.First(cust => cust.Name.Equals(username));
            if (!customer.customerOrders.ContainsKey(product))
            {
                customer.customerOrders.Add(product, quantity);
            }
            else
            {
                customer.customerOrders[product] += quantity;
            }
            customer.Bill += quantity * shopMenu[product];
        }
        else
        {
            Customer customer = new Customer(username);
            customer.customerOrders.Add(product, quantity);
            customer.Bill += quantity * shopMenu[product];
            allCustomerObjects.Add(customer);
        }
    }

    private static void FillOutShopMenu(Dictionary<string, decimal> shopMenu, string entity, decimal price)
    {
        if (!shopMenu.ContainsKey(entity))
        {
            shopMenu.Add(entity, price);
        }
        shopMenu[entity] = price;
    }

    private static void PrintResults(List<Customer> allCustomerObjects)
    {
        foreach (Customer customer in allCustomerObjects.OrderBy(n => n.Name))
        {
            Console.WriteLine(customer.Name);
            foreach (var customerProduct in customer.GetList())
            {
                Console.WriteLine("-- {0} - {1}", customerProduct.Key, customerProduct.Value);
            }
            Console.WriteLine("Bill: {0:f2}", customer.Bill);
        }
        decimal totalSum = allCustomerObjects.Sum(c => c.Bill);
        Console.WriteLine("Total bill: {0:f2}", totalSum);
    }

}

public class Customer
{
    public string Name { get; set; }
    public Dictionary<string, int> customerOrders { get; set; }
    public decimal Bill { get; set; }

    public Customer(string name)
    {
        Name = name;
        customerOrders = new Dictionary<string, int>();
    }

    public Dictionary<string, int> GetList()
    {
        return customerOrders;
    }
}


