namespace CommandPattern.Commands
{
    public class PrintNumberCommand : Command
    {
        public PrintNumberCommand(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new PrintNumberCommand(data);
        }

        public override void Execute()
        {
            System.Console.WriteLine(this.data.MyNumber);
        }
    }
}
