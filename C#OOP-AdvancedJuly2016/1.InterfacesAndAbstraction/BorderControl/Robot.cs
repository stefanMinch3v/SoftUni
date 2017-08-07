namespace BorderControl
{
    public class Robot : Alive
    {
        public Robot(string model, string id) 
            : base(id)
        {
            this.Model = model;
        }

        public string Model { get; }
    }
}
