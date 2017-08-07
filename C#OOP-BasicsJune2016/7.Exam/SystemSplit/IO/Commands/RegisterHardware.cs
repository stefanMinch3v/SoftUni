namespace SystemSplit.IO.Commands
{
    using Factory;
    using Interfaces;
    using Repository;

    public abstract class RegisterHardware : Command, IHardwareCreation
    {
        public RegisterHardware(Data data, string[] input, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(data, input, hardwareFactory, softwareFactory)
        {
        }

        public abstract Computer CreateHardware();

        public override void Execute()
        {
            Hardware hardware = this.CreateHardware() as Hardware;
            base.Data.AddHardware(hardware);
        }
    }
}
