using System;

namespace ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        private string name;
        private int age;
        private string country;

        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
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

        public string Country
        {
            get
            {
                return this.country;
            }

            private set
            {
                this.country = value;
            }
        }

        string IPerson.GetName()
        {
            return this.Name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }

        public string ExplicitCalledGetName()
        {
            return (this as IResident).GetName();
            //second way
            //IResident ir = this;
            //return ir.GetName();
        }

    }
}
