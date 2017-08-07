namespace SystemSplit.IO.Commands
{
    using Factory;
    using Interfaces;
    using Repository;

    public class SystemSplit : Command
    {
        public SystemSplit(Data data, string[] input, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory) 
            : base(data, input, hardwareFactory, softwareFactory)
        {
        }

        public override void Execute()
        {
            base.Data.PrintSystemSplitCommand();
        }
    }
}
