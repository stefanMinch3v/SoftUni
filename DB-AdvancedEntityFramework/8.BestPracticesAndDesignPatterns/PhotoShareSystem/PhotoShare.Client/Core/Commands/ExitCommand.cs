namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Attributes;

    [Command("Exit")]
    public class ExitCommand : Command
    {
        public override string Execute()
        {
            Console.WriteLine("Bye-bye!");
            Environment.Exit(0);
            return "Bye-bye!";
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
