using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PawInc
{
    public abstract class Animals
    {
        private string name;
        private int age;
        private bool cleasingStatus;
        private string adoptionCenterName;
        private bool castrate;

        protected Animals(string name, int age, string adoptionCenterName)
        {
            this.Age = age;
            this.Name = name;
            this.AdoptionCenterName = adoptionCenterName;
            this.cleasingStatus = false;
            this.castrate = false;
        }

        //public List<Animals> AllAnimals{ get; protected set; }
        public string AdoptionCenterName
        {
            get
            {
                return this.adoptionCenterName;
            }
            private set
            {
                this.adoptionCenterName = value;
            }
        }

        public bool Castrate
        {
            get
            {
                return this.castrate;
            }
            set
            {
                this.castrate = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public void ChangeStatusToClean()
        {
            this.cleasingStatus = true;
        }
    }
}