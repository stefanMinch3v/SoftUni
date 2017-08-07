namespace SystemSplit.IO.Commands
{
    using Interfaces;
    using Factory;
    using Repository;

    public abstract class RegisterSoftware : Command, ISoftwareCreation
    {
        public RegisterSoftware(Data data, string[] input, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory) 
            : base(data, input, hardwareFactory, softwareFactory)
        {
        }

        public abstract Computer CreateSoftware();

        public override void Execute()
        {
            string hardwareName = base.Input[1];
            if (base.Data.Hardware.ContainsKey(hardwareName))
            {
                Software software = this.CreateSoftware() as Software;
                if (this.Data.Hardware[hardwareName].CanRegisterSoftware(software))
                {
                    this.Data.Hardware[hardwareName].RegisterSoftware(software);

                    //if (!base.Data.Software.ContainsKey(software.Name))
                    //{
                    //    base.Data.Software.Add(software.Name, software);
                    //}
                }                
            }
        }
    }
}
