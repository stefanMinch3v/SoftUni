namespace PhotoShare.Client.Core.Commands
{
    public abstract class Command
    {
        protected string[] data;

        public Command(string[] data)
        {
            this.data = data;
        }

        public abstract void Execute();

        public abstract Command Create(string[] data);
    }
}
