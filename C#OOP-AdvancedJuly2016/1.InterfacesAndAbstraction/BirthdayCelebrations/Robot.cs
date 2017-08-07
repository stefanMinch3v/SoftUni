namespace BirthdayCelebrations
{
    public class Robot : Person
    {
        public Robot(string model, string id) 
            : base(id)
        {
            this.Model = model;
        }

        public string Model { get; }
    }
}
