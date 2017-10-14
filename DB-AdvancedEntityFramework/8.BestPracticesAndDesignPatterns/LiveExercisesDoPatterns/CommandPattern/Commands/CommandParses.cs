using System.Collections.Generic;

namespace CommandPattern.Commands
{
    public class CommandParses
    {
        private Dictionary<string, Command> commands;

        public CommandParses()
        {
            Initialize();
        }

        public Command Parse(string commandString, MyData data)
        {
            //instead of switch because its redundant here
            if (this.commands.ContainsKey(commandString))
            {
                return this.commands[commandString].Create(data);
            }
            else
            {
                return new NotFoundCommand(null);
            }
        }

        private void Initialize()
        {
            this.commands = new Dictionary<string, Command>
            {
                {"increase", new IncreaseNumberCommand(null)},
                {"print", new PrintStringCommand(null)},
                {"print number", new PrintNumberCommand(null)}
            };
        }
    }
}
