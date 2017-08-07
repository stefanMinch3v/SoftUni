namespace SystemSplit.IO.Commands
{
    using Factory;
    using Interfaces;
    using Repository;

    public abstract class Command : IExecutable
    {
        private string[] input;
        private Data data;
        private HardwareFactory hardwareFactory;
        private SoftwareFactory softwareFactory;

        protected Command(Data data, string[] input, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
        {
            this.input = input;
            this.data = data;
            this.hardwareFactory = hardwareFactory;
            this.softwareFactory = softwareFactory;
        }

        protected Data Data => this.data;

        protected string[] Input => this.input;

        protected HardwareFactory HardwareFactory => this.hardwareFactory;

        protected SoftwareFactory SoftwareFactory => this.softwareFactory;

        public abstract void Execute();
    }
}
