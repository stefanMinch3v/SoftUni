namespace SystemSplit
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Hardware : Computer
    {
        #region FIELDS

        //private string type;
        //private string name;
        private int maxCapacity;
        private int maxMemory;
        private int capacityUsing;
        private int memoryUsing;
        private List<Software> software;

        #endregion

        #region CONSTRUCTOR

        public Hardware(string type, string name, int maxCapacity, int maxMemory) 
            : base(type, name)
        {
            this.MaxMemory = maxMemory;
            this.MaxCapacity = maxCapacity;
            this.software = new List<Software>();
        }
        //protected Hardware(string type, string name, int maxCapacity, int maxMemory)
        //{
        //    this.type = type;
        //    this.name = name;
        //    this.MaxMemory = maxMemory;
        //    this.MaxCapacity = maxCapacity;
        //    this.software = new List<Software>();
        //}

        #endregion

        #region PROPERTIES

        public virtual int MaxCapacity
        {
            get
            {
                return this.maxCapacity;
            }
            protected set
            {
                this.maxCapacity = value;
            }
        }

        public virtual int MaxMemory
        {
            get
            {
                return this.maxMemory;
            }
            protected set
            {
                this.maxMemory = value;
            }
        }

        //public string Name => this.name;

        //public string Type => this.type;

        public int CapacityUsing => this.capacityUsing;

        public int MemoryUsing => this.memoryUsing;

        public List<Software> Software => this.software;

        #endregion

        #region METHODS

        public void RegisterSoftware(Software s)
        {
            this.capacityUsing += s.CapacityConsumption;
            this.memoryUsing += s.MemoryConsumption;
            this.software.Add(s);
        }

        public bool CanRegisterSoftware(Software s)
        {
            if (s.CapacityConsumption + this.CapacityUsing > this.MaxCapacity ||
                s.MemoryConsumption + this.MemoryUsing > this.MaxMemory)
            {
                return false;
            }

            return true;
        }

        public void ReleaseSoftware(string softwareName)
        {
            Software s = this.software.FirstOrDefault(x => x.Name == softwareName);
            if (s != null)
            {
                this.capacityUsing -= s.CapacityConsumption;
                this.memoryUsing -= s.MemoryConsumption;
                this.software.Remove(s);
            }
        }

        #endregion
    }
}