using System;

namespace ConcatenateData
{
    class ConcatenateData
    {
        static void Main()
        {
            Console.WriteLine("Hello, please enter your details!");
            Console.Write("Your first name: ");
            string FirstName = Console.ReadLine();
            Console.Write("Your last name: ");
            string LastName = Console.ReadLine();
            Console.Write("Your age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Your town: ");
            string town = Console.ReadLine();
            Console.WriteLine("You are {0} {1}, a {2} -years old person from {3}.", FirstName, LastName, age, town);
        }
    }
}
