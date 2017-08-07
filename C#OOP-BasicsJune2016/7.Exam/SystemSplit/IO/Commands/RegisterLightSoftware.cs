namespace SystemSplit.IO.Commands
{
    using Factory;
    using Interfaces;
    using Repository;

    public class RegisterLightSoftware : RegisterSoftware
    {
        public RegisterLightSoftware(Data data, string[] input, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory) 
            : base(data, input, hardwareFactory, softwareFactory)
        {
        }

        public override Computer CreateSoftware()
        {
            return this.SoftwareFactory.CreateLightSoftware(base.Input);
        }
    }
}
