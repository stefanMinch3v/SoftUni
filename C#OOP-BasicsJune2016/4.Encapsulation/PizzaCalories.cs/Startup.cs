using System;

public class Startup
{
    public static void Main()
    {
        try
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commandLine = input.Split();
                string checkInput = commandLine[0];

                if (checkInput == "Dough" || checkInput == "Topping")
                {
                    if (checkInput == "Dough")
                    {
                        string flour = commandLine[1];
                        string bakingTechnique = commandLine[2];
                        double weight = double.Parse(commandLine[3]);
                        Dough dough = new Dough(flour, bakingTechnique, weight);
                        Console.WriteLine($"{dough.GetCalories():F2}");
                    }
                    else
                    {
                        string toppingType = commandLine[1];
                        double weight = double.Parse(commandLine[2]);
                        Toppings toppings = new Toppings(toppingType, weight);
                        Console.WriteLine($"{toppings.GetCalories():F2}");
                    }
                }
                else if (checkInput == "Pizza")
                {
                    int numberOfToppings = int.Parse(commandLine[2]);
                    string pizzaName = commandLine[1];

                    if (numberOfToppings > 10 || numberOfToppings < 0)
                    {
                        throw new ArgumentException("Number of toppings should be in range [0..10].");
                    }
                    Pizza pizza = new Pizza(pizzaName);

                    string inputDough = Console.ReadLine();
                    string[] splitDough = inputDough.Split();

                    if (splitDough[0] == "Dough")
                    {
                        string dough = splitDough[1];
                        string bakingTechnique = splitDough[2];
                        double weight = double.Parse(splitDough[3]);
                        pizza.AddDough(dough, bakingTechnique, weight);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid type of dough.");
                    }

                    for (int i = 0; i < numberOfToppings; i++)
                    {
                        string[] inputTopping = Console.ReadLine().Split();

                        string toppingType = inputTopping[1];
                        double weight = double.Parse(inputTopping[2]);
                        pizza.AddToppings(toppingType, weight);
                    }

                    Console.WriteLine($"{pizza.Name} - {pizza.PrintAllCalories():F2} Calories.");
                }

                input = Console.ReadLine();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}
