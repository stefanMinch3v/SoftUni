using System;

namespace WildFarm
{
    public class Startup
    {
        public static void Main()
        {
            Animal animal = null;
            Food food = null;

            string command = Console.ReadLine();

            while(!command.Contains("End"))
            { 
                try
                {
                    string[] inputFirstLine = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string animalType = inputFirstLine[0];
                    string animalName = inputFirstLine[1];
                    double animalWeight = double.Parse(inputFirstLine[2]);
                    string animalLivingRegion = inputFirstLine[3];

                    switch (animalType)
                    {
                        case "Mouse":
                            animal = new Mouse(animalType, animalName, animalWeight, animalLivingRegion);
                            break;
                        case "Zebra":
                            animal = new Zebra(animalType, animalName, animalWeight, animalLivingRegion);
                            break;
                        case "Tiger":
                            animal = new Tiger(animalType, animalName, animalWeight, animalLivingRegion);
                            break;
                        case "Cat":
                            string breed = inputFirstLine[4];
                            animal = new Cat(animalType, animalName, animalWeight, animalLivingRegion, breed);
                            break;
                        default:
                            break;
                    }

                    string[] inputSecondLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                         
                    string foodType = inputSecondLine[0];
                    int quantity = int.Parse(inputSecondLine[1]);

                    if (foodType == "Vegetable")
                    {
                        food = new Vegetable(quantity);
                    }
                    else if (foodType == "Meat")
                    {
                        food = new Meat(quantity);
                    }

                    animal.MakeSound();
                    animal.EatFood(food);
                    Console.WriteLine(animal);

                    command = Console.ReadLine();
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    Console.WriteLine(animal);
                    command = Console.ReadLine();
                }        
            }

        }
    }
}
