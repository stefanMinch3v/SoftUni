namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ExitCommand : Command
    {
        public ExitCommand(string[] data) 
            : base(data)
        {
        }

        public override Command Create(string[] data)
        {
            return new ExitCommand(data);
        }

        public override void Execute()
        {
            Console.WriteLine("Bye-bye!, press any key to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
