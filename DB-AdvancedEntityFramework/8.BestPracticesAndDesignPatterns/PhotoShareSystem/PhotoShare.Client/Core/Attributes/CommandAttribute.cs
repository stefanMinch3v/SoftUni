using System;

namespace PhotoShare.Client.Core.Attributes
{
    internal class CommandAttribute : Attribute
    {
        private string commandString;

        public CommandAttribute(string commandString)
        {
            this.commandString = commandString;
        }

        public string GetCommandString => this.commandString;
    }
}
