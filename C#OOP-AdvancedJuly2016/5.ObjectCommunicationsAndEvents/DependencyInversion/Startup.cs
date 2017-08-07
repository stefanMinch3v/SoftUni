namespace DependencyInversion
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var calculator = new PrimitiveCalculator(new AdditionStrategy());

            while (input != "End")
            {
                string[] commandLine = input.Split();
                string operation = commandLine[0];

                int emptyValue;
                var isNumber = int.TryParse(operation, out emptyValue);

                if (!isNumber)
                {
                    if (operation == "mode")
                    {
                        char symbol = char.Parse(commandLine[1]);

                        calculator.ChangeStrategy(symbol);
                    }
                }
                else
                {
                    int firstOperand = int.Parse(commandLine[0]);
                    int secondOperand = int.Parse(commandLine[1]);

                    Console.WriteLine(calculator.PerformCalculation(firstOperand, secondOperand));
                }
                
                input = Console.ReadLine();
            }
        }
    }
}
