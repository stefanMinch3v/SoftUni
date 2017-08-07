namespace SystemSplit.IO.Commands
{
    using Factory;
    using Repository;

    public class Dump : Command
    {
        public Dump(Data data, string[] input, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory) 
            : base(data, input, hardwareFactory, softwareFactory)
        {
        }

        public override void Execute()
        {
            string hardwareName = base.Input[1];
            base.Data.Dump(hardwareName);
        }
    }
}
