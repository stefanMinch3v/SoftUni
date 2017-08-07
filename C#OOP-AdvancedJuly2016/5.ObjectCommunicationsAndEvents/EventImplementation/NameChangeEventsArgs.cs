namespace EventImplementation
{
    using System;

    public class NameChangeEventsArgs : EventArgs
    {
        public NameChangeEventsArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
