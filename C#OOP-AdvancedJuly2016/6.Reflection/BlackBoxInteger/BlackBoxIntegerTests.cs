namespace BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var constructor = typeof(BlackBoxIntegerClass).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
            var blackBox = constructor.Invoke(new object[] { });
            var fields = typeof(BlackBoxIntegerClass).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldName = fields.FirstOrDefault().Name;

            while (input != "END")
            {
                string[] commandLine = input.Split('_');
                string command = commandLine[0];
                int number = int.Parse(commandLine[1]);

                var method = typeof(BlackBoxIntegerClass).GetMethod(command, BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(blackBox, new object[] {number});

                var field = typeof(BlackBoxIntegerClass).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);

                Console.WriteLine(field.GetValue(blackBox));

                input = Console.ReadLine();
            }
        }
    }
}
