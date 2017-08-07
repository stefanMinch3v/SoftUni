namespace EventImplementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventsArgs args);

    public class Dispatcher
    {
        private string name;

        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                OnNameChange(new NameChangeEventsArgs(value));
            }
        }

        public void OnNameChange(NameChangeEventsArgs args)
        {
            NameChange?.Invoke(this, args);
            //this.NameChange(this, args);
        }
    }
}
