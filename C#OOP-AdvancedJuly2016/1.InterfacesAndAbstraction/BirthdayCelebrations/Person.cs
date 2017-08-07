namespace BirthdayCelebrations
{
    public abstract class Person
    {
        public Person(string id)
        {
            this.Id = id;
        }

        public string Id { get; protected set; }
    }
}
