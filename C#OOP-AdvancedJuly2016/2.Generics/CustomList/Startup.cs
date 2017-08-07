using System;

namespace CustomList
{
    public class Startup
    {
        public static void Main()
        {
            MyGenericList<string> collection = new MyGenericList<string>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commands = input.Split();
                switch (commands[0])
                {
                    case "Add":
                        collection.Add(commands[1]);
                        break;
                    case "Remove":
                        collection.Remove(int.Parse(commands[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(collection.Contains(commands[1]));
                        break;
                    case "Swap":
                        collection.Swap(int.Parse(commands[1]), int.Parse(commands[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(collection.CountGreaterThan(commands[1]));
                        break;
                    case "Max":
                        Console.WriteLine(collection.Max());
                        break;
                    case "Min":
                        Console.WriteLine(collection.Min());
                        break;
                    case "Print":
                        //Console.WriteLine(collection.ToString());
                        collection.ForEach();
                        break;
                    case "Sort":
                        collection.Sort();
                        break;
                    default:
                        break;
                }


                input = Console.ReadLine();
            }
        }
    }
}
