using System;

public class Startup
{
    public static void Main()
    {
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] commandLine = input.Split();
            string operation = commandLine[0];
            double num = double.Parse(commandLine[1]);
            double num2 = double.Parse(commandLine[2]);
            switch (operation)
            {
                case "Sum":
                    Console.WriteLine(MathUtil.Sum(num, num2));
                    break;
                case "Multiply":
                    Console.WriteLine(MathUtil.Multiply(num, num2));
                    break;
                case "Percentage":
                    Console.WriteLine(MathUtil.Percentage(num, num2));
                    break;
                case "Divide":
                    Console.WriteLine(MathUtil.Divide(num, num2));
                    break;
                case "Subtract":
                    Console.WriteLine(MathUtil.Subtract(num, num2));
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }
    }
}