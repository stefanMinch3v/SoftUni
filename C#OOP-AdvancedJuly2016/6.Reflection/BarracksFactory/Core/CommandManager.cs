namespace BarracksFactory.Core
{
    using System;
    using Contracts;
    using System.Reflection;
    using System.Linq;
    using Attributes;
    using Data;
    using Factories;

    public class CommandManager : ICommandInterpreter
    {
        [Inject]
        private IRepository repository = new UnitRepository();
        [Inject]
        private IUnitFactory unitFactory = new UnitFactory();

        // solved: refactor for Problem 4
        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Type commandType = Assembly.GetExecutingAssembly().DefinedTypes
                        //first way //.FirstOrDefault(x => x.Name == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + "Command");
                        .FirstOrDefault(x => x.Name.ToLower() == commandName.ToLower() + "command"); // another way

            var command = Activator.CreateInstance(commandType, new object[] { data }) as IExecutable;
            InjectDependencies(command);

            return command;
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            var fieldsOfCommand = command.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldsOfInterpreter = typeof(CommandManager).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fieldsOfCommand)
            {
                var fieldAttribute = field.GetCustomAttribute(typeof(InjectAttribute));
                if (fieldAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == field.FieldType))
                    {
                        field.SetValue(command, fieldsOfInterpreter.First(x => x.FieldType == field.FieldType).GetValue(this));
                    }
                }
            }

            return command;
        }
    }
}
