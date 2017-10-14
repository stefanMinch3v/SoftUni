using System;

namespace CommandPattern.Commands
{
    public class PrintStringCommand : Command
    {
        public PrintStringCommand(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new PrintStringCommand(data);
        }

        public override void Execute()
        {
            Console.WriteLine(this.data.MyString);
        }
    }
}
