namespace SystemSplit.IO.Commands
{
    using Factory;
    using Interfaces;
    using Repository;

    public class RegisterPowerHardware : RegisterHardware
    {
        public RegisterPowerHardware(Data data, string[] input, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(data, input, hardwareFactory, softwareFactory)
        {
        }

        public override Computer CreateHardware()
        {
            return base.HardwareFactory.CreatePowerHardware(base.Input);
        }
    }
}
