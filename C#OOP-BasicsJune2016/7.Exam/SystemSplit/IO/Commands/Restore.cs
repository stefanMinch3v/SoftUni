namespace SystemSplit.IO.Commands
{
    using Factory;
    using Interfaces;
    using Repository;

    class Restore : Command
    {
        public Restore(Data data, string[] input, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory) 
            : base(data, input, hardwareFactory, softwareFactory)
        {
        }

        public override void Execute()
        {
            string hardwareName = base.Input[1];
            base.Data.Restore(hardwareName);
        }
    }
}
