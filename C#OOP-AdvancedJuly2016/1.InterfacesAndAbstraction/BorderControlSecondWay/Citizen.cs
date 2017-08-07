using System;

namespace BorderControlSecondWay
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
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
            set
            {
                this.name = value;
            }
        }

        public string Id { get; set; }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
