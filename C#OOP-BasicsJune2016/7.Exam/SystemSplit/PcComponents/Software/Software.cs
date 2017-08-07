namespace SystemSplit
{
    public abstract class Software : Computer
    {
        #region FIELDS

        private string name;
        private string type;
        private string hardwareName;
        private int memoryConsumption;
        private int capacityConsumption;

        #endregion

        #region CONSTRUCTOR

        public Software(string type, string hardwareName, string name, int capacityConsumption, int memoryConsumption) 
            : base(type, hardwareName)
        {
            this.name = name.Trim();
            this.type = type;
            this.MemoryConsumption = memoryConsumption;
            this.CapacityConsumption = capacityConsumption;
        }

        //protected Software(string type, string hardware, string name, int capacityConsumption, int memoryConsumption)
        //{
        //    this.hardwareName = hardware;
        //    this.name = name.Trim();
        //    this.type = type;
        //    this.MemoryConsumption = memoryConsumption;
        //    this.CapacityConsumption = capacityConsumption;
        //}

        #endregion Constructor

        #region PROPERTIES

        public virtual int CapacityConsumption
        {
            get
            {
                return this.capacityConsumption;
            }
            protected set
            {
                if (value <= 0)
                {
                    value = 0;
                }

                this.capacityConsumption = value;
            }
        }

        public virtual int MemoryConsumption
        {
            get
            {
                return this.memoryConsumption;
            }
            protected set
            {
                if (value <= 0)
                {
                    value = 0;
                }

                this.memoryConsumption = value;
            }
        }

        public string Name => this.name;

        public string Type => this.type;

        #endregion

        #region METHODS

        public override string ToString()
        {
            return this.Name;
        }

        #endregion
    }
}