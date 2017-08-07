using System;

namespace FoodShortage
{
    public class Citizen :  Person
    {
        private string birthdate;
        private string id;

        public Citizen(string name, int age, string id, string birthdate) 
            :base(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }

        public string Birthdate
        {
            get
            {
                return this.birthdate;
            }
            private set
            {
                this.birthdate = value;
            }
        }

        public override void BuyFood()
        {
            base.Food += 10;
        }
    }
}
