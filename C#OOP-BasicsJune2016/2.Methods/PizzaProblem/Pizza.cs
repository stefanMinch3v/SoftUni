using System;
using System.Collections.Generic;

public class Pizza
{
    private SortedDictionary<int, List<string>> pizza = new SortedDictionary<int, List<string>>();

    public SortedDictionary<int, List<string>> SetDictionary(int number, string pizzaType)
    {
        if (!pizza.ContainsKey(number))
        {
            pizza.Add(number, new List<string>());
        }
        pizza[number].Add(pizzaType);

        return pizza;
    }
    public SortedDictionary<int, List<string>> GetDictionary => this.pizza;
}
