namespace PhotoShare.Client.Core.Commands
{
    public abstract class Command
    {
        protected string[] data;

        public abstract string Execute();

        public abstract void InsertData(string[] data);
    }
}
