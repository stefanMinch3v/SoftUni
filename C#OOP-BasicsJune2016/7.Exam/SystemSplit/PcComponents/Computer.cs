namespace SystemSplit
{
    public abstract class Computer
    {
        private string hardwareName;
        private string type;

        public Computer(string type, string hardwareName)
        {
            this.HardwareName = hardwareName;
            this.Type = type;
        }

        public string HardwareName

        {
            get
            {
                return this.hardwareName;
            }
            protected set
            {
                this.hardwareName = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            protected set
            {
                this.type = value;
            }
        }
    }
}
