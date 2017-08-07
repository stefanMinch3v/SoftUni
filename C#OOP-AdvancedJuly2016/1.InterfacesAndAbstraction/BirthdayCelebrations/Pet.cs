using System;

namespace BirthdayCelebrations
{
    public class Pet : IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Birthdate { get; }

        public string Name { get; }
    }
}
