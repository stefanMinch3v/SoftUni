using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        List<Person> personsCollection = new List<Person>();
        List<Product> productsCollection = new List<Product>();
        Dictionary<string, List<string>> finalResults = new Dictionary<string, List<string>>();

        try
        {
            string[] currentPerson = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] currentProduct = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < currentPerson.Length; i += 2)
            {
                string name = currentPerson[i];
                decimal money = decimal.Parse(currentPerson[i + 1]);

                Person person = new Person(name, money);
                personsCollection.Add(person);
            }
            for (int i = 0; i < currentProduct.Length; i += 2)
            {
                string name = currentProduct[i];
                decimal cost = decimal.Parse(currentProduct[i + 1]);

                Product product = new Product(name, cost);
                productsCollection.Add(product);
            }


            string operation = Console.ReadLine();
            while (operation != "END")
            {
                string[] commandLine = operation.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string username = commandLine[0];
                string product = commandLine[1];
                decimal result = 0;
                foreach (var person in personsCollection.Where(p => p.Name == username))
                {
                    foreach (var item in productsCollection.Where(p => p.Name == product))
                    {
                        result = person.BuyProduct(item.Cost);
                    }
                }
                if (result == -1)
                {
                    Console.WriteLine($"{username} can't afford {product}");
                    PutEmptyBag(finalResults, username);
                }
                else
                {
                    Console.WriteLine($"{username} bought {product}");
                    PutItemsInBag(finalResults, username, product);
                }

                operation = Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        foreach (var kvp in finalResults)
        {
            if (kvp.Value.Count == 0)
            {
                Console.WriteLine($"{kvp.Key} - Nothing bought");
            }
            else
            {
                Console.WriteLine($"{kvp.Key} - {string.Join(", ", kvp.Value)}");
            }  
        }

    }

    private static void PutEmptyBag(Dictionary<string, List<string>> finalResults, string username)
    {
        if (!finalResults.ContainsKey(username))
        {
            finalResults.Add(username, new List<string>());
        }
    }

    private static void PutItemsInBag(Dictionary<string, List<string>> finalResults, string username, string product)
    {
        if (!finalResults.ContainsKey(username))
        {
            finalResults.Add(username, new List<string>() {product});
        }
        else
        {
            finalResults[username].Add(product);
        }

    }
}
