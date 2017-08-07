namespace SystemSplit
{
    using System;
    using Factory;
    using IO;
    using IO.Commands;
    using Repository;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Data data = new Data();
            CommandInterpreter commandInterpreter = new CommandInterpreter();
            HardwareFactory hardwareFactory = new HardwareFactory();
            SoftwareFactory softwareFactory = new SoftwareFactory();

            while (!input.Contains("System Split"))
            {
                string[] commandLine = input.Split(new char[] { '(', ')', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Command command = commandInterpreter.ParseCommand(data, commandLine, hardwareFactory, softwareFactory);
                    command.Execute();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                

                input = Console.ReadLine();
            }

            data.PrintSystemSplitCommand();
        }
    }
}
