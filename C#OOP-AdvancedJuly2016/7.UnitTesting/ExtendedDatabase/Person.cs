namespace ExtendedDatabase
{
    public class Person
    {
        public Person(string username, long id)
        {
            this.Username = username;
            this.Id = id;
        }

        public long Id { get; private set; }

        public string Username { get; private set; }

        public override bool Equals(object obj)
        {
            Person anotherPerson = obj as Person;
            if (obj == null)
            {
                return false;
            }

            if (this.Username == anotherPerson.Username || this.Id == anotherPerson.Id)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ this.Username.GetHashCode();
        }
    }
}
