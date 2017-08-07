namespace ExtendedDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtendedDatabaseClass
    {
        private const int MaxCapacity = 16;
        private Person[] persons;
        private int currentElement;

        public ExtendedDatabaseClass(Person[] person)
        {
            this.Persons = person;
        }

        public Person[] Persons
        {
            get
            {
                List<Person> person = new List<Person>();
                for (int i = 0; i < this.currentElement; i++)
                {
                    person.Add(persons[i]);
                }

                return person.ToArray();
            }
            private set
            {
                if (value.Length > 16 || value.Length < 1)
                {
                    throw new InvalidOperationException("The collection must be between 1 and 16 persons!");
                }

                this.persons = new Person[MaxCapacity];

                for (int i = 0; i < value.Length; i++)
                {
                    this.persons[i] = value[i];
                }

                this.currentElement = value.Length;
            }
        }

        /// <summary>
        /// The length of the array (16 elements fixed!)
        /// </summary>
        public int Capacity { get { return MaxCapacity; } }

        /// <summary>
        /// The numbers of elements in the array out of 16
        /// </summary>
        public int Count { get { return this.currentElement; } }

        public void Remove()
        {
            if (this.currentElement == 0)
            {
                throw new InvalidOperationException("Cannot remove element from empty database!");
            }

            this.persons[currentElement] = null;
            currentElement--;
        }

        public void Add(Person person)
        {
            if (this.currentElement == MaxCapacity)
            {
                throw new IndexOutOfRangeException("You've reach the max capacity and cannot add more elements!");
            }
            for (int i = 0; i < this.Count; i++)
            {
                if (this.persons[i].Equals(person))
                {
                    throw new InvalidOperationException("There is already a person with this id/username!");
                }
            }

            this.persons[currentElement] = person;
            currentElement++;

            //it can be done for the specific id and specific username with :
            //if (this.Persons.FirstOrDefault(p => p.Id == person.Id) != null)
            //{
            //    throw new InvalidOperationException("User with that id is already in the database.");
            //}
            //if (this.Persons.FirstOrDefault(p => p.Username == person.Username) != null)
            //{
            //    throw new InvalidOperationException("User with that username is already in the database.");
            //}
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new InvalidOperationException("The username that you're looking for cannot be null!");
            }

            Person searchPerson = this.Persons.FirstOrDefault(p => p.Username == username);
            if (searchPerson == null)
            {
                throw new InvalidOperationException("The desired username doesn't exists in the system!");
            }

            return searchPerson;
        }

        public Person FindById(long searchingId)
        {
            if (searchingId < 0)
            {
                throw new InvalidOperationException("Id number cannot be less than zero!");
            }

            Person searchPerson = this.Persons.FirstOrDefault(p => p.Id == searchingId);
            if (searchPerson == null)
            {
                throw new InvalidOperationException("The desired id doesn't exists in the system!");
            }

            return searchPerson;
        }
    }
}
