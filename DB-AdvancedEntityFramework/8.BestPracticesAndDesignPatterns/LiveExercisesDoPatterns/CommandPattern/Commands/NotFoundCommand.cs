namespace CommandPattern.Commands
{
    class NotFoundCommand : Command
    {
        public NotFoundCommand(MyData data)
            : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new NotFoundCommand(data);
        }

        public override void Execute()
        {
            System.Console.WriteLine("Command not found!");
        }
    }
}
