using System;

namespace Animals
{
    public class Startup
    {
        public static void Main()
        {

            string input = Console.ReadLine();
            while (input != "Beast!")
            {
                try
                {
                    string[] animals = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = animals[0];
                    int age = 0;
                    bool successfullyCheckAge = Int32.TryParse(animals[1], out age);
                    if (!successfullyCheckAge)
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                    string gender = animals[2];

                    switch (input)
                    {
                        case "Dog":
                            Dog dog = new Dog(name, gender, age);
                            Console.WriteLine("Dog");
                            Console.WriteLine(dog);
                            break;
                        case "Cat":
                            Cat cat = new Cat(name, gender, age);
                            Console.WriteLine("Cat");
                            Console.WriteLine(cat);
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, gender, age);
                            Console.WriteLine("Frog");
                            Console.WriteLine(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(name, age);
                            Console.WriteLine("Kitten");
                            Console.WriteLine(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            Console.WriteLine("Tomcat");
                            Console.WriteLine(tomcat);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }

                    input = Console.ReadLine();
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    input = Console.ReadLine();
                }
            }
        }
    }
}

