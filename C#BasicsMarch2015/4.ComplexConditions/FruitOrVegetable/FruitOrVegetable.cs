using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitOrVegetable
{
    class FruitOrVegetable
    {
        static void Main(string[] args)
        {
            Console.Write("Enter fruit or vegetable: ");
            var kind = Console.ReadLine().ToLower();
            if(kind == "banana" || kind == "apple" || kind == "kiwi" || kind == "cherry" || kind == "lemon" || kind == "grapes")
            {
                Console.WriteLine("Fruit");
            }
            else if(kind == "tomato" || kind == "cucumber" || kind == "pepper" || kind == "carrot")
            {
                Console.WriteLine("Vegetable");
            }
            else
            {
                Console.WriteLine("Unknown");
            }
        }
    }
}
