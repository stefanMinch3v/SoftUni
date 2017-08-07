using System;

namespace BirthdayCelebrations
{
    public class Citizen : IBirthdate
    {
        public Citizen(string name, int age, string id, string birthdate) 
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public string Name{ get;}

        public int Age { get;}

        public string Birthdate { get; }
    }
}
