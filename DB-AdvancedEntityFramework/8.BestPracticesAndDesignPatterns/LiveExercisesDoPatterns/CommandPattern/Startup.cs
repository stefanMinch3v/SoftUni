using CommandPattern.Commands;
using System;

namespace CommandPattern
{
    public class Startup
    {
        public static void Main()
        {
            var parser = new CommandParses();
            MyData data = new MyData()
            {
                MyNumber = 26,
                MyString = "Some useless data"
            };

            string input = Console.ReadLine();

            while (input != "exit")
            {
                var cmd = parser.Parse(input, data);
                cmd.Execute();

                input = Console.ReadLine();
            }
            
        }
    }

    public class MyData
    {
        public string MyString { get; set; }

        public int MyNumber { get; set; }
    }
}
