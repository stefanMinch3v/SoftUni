namespace SystemSplit.IO.Commands
{
    using Factory;
    using Interfaces;
    using Repository;

    public class RegisterHeavyHardware : RegisterHardware
    {
        public RegisterHeavyHardware(Data data, string[] input, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(data, input, hardwareFactory, softwareFactory)
        {
        }

        public override Computer CreateHardware()
        {
            return base.HardwareFactory.CreateHeavyHardware(base.Input);
        }
    }
}
