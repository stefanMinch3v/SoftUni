namespace SystemSplit.IO.Commands
{
    using Factory;
    using Interfaces;
    using Repository;

    public class RegisterExpressSoftware : RegisterSoftware
    {
        public RegisterExpressSoftware(Data data, string[] input, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory) 
            : base(data, input, hardwareFactory, softwareFactory)
        {
        }

        public override Computer CreateSoftware()
        {
            return this.SoftwareFactory.CreateExpressSoftware(base.Input);
        }
    }
}
