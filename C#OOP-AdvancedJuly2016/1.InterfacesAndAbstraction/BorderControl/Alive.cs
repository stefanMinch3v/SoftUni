namespace BorderControl
{
    public abstract class Alive
    {
        public Alive(string id)
        {
            this.Id = id;
        }

        public string Id { get; protected set; }
    }
}
