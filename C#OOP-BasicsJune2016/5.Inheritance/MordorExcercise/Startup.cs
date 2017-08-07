using System;

public class Startup
{
    public static void Main()
    {
        string[] input = Console.ReadLine().ToLower().Split(new char[] { ' ',',' }, StringSplitOptions.RemoveEmptyEntries);
        int happiness = 0;
        foreach (var item in input)
        {
            switch (item)
            {
                case "cram":
                    happiness += FoodFactory.GetSomeFood("cram").Happiness;
                    break;
                case "lembass":
                    happiness += FoodFactory.GetSomeFood("lembass").Happiness;
                    break;
                case "apple":
                    happiness += FoodFactory.GetSomeFood("apple").Happiness;
                    break;
                case "melon":
                    happiness += FoodFactory.GetSomeFood("melon").Happiness;
                    break;
                case "honeycake":
                    happiness += FoodFactory.GetSomeFood("honeycake").Happiness;
                    break;
                case "mushrooms":
                    happiness += FoodFactory.GetSomeFood("mushrooms").Happiness;
                    break;
                default:
                    happiness += FoodFactory.GetSomeFood("anythingElse").Happiness;
                    break;
            }
        }
        if (happiness < -5)
        {
            Console.WriteLine(happiness);
            Console.WriteLine(MoodFactory.SeeGandalfsMood("angry").Type);
        }
        else if (happiness >= -5 && happiness <= 0)
        {
            Console.WriteLine(happiness);
            Console.WriteLine(MoodFactory.SeeGandalfsMood("sad").Type);
        }
        else if (happiness > 0 && happiness <= 15)
        {
            Console.WriteLine(happiness);
            Console.WriteLine(MoodFactory.SeeGandalfsMood("happy").Type);
        }
        else
        {
            Console.WriteLine(happiness);
            Console.WriteLine(MoodFactory.SeeGandalfsMood("javascript").Type);
        }

    }
}
