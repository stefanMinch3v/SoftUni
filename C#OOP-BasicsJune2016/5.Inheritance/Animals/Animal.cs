using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private string gender;
        private int age;

        public Animal(string name, string gender, int age)
        {
            Name = name;
            Gender = gender;
            Age = age;
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }
        public virtual string Gender
        {
            get
            {
                return this.gender;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) || value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("{0} {1} {2}{3}", this.Name, this.Age, this.Gender, Environment.NewLine));
            return sb.ToString();
        }
    }
}

