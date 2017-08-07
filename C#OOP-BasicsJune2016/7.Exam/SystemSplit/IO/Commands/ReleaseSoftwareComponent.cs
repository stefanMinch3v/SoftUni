namespace SystemSplit.IO.Commands
{
    using System.Linq;
    using Factory;
    using Repository;
    using Interfaces;

    class ReleaseSoftwareComponent : Command
    {
        public ReleaseSoftwareComponent(Data data, string[] input, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory) 
            : base(data, input, hardwareFactory, softwareFactory)
        {
        }

        public override void Execute()
        {
            string hardwareName = base.Input[1];
            string softwareName = base.Input[2];
            if (base.Data.Hardware.ContainsKey(hardwareName))
            {
                base.Data.Hardware[hardwareName].ReleaseSoftware(softwareName);
                //base.Data.Software.Remove(softwareName); 
            }
        }
    }
}
