namespace BorderControlSecondWay
{
    class Robot : IIdentifiable
    {
        private string model;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;  
        }

        public string Id { get; set; }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
