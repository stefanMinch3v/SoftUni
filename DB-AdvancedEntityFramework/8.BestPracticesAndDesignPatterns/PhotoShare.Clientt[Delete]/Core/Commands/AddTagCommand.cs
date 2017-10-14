namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using PhotoShare.Data;
    using System;
    using System.Linq;
    using Utilities;

    public class AddTagCommand : Command
    {
        public AddTagCommand(string[] data) 
            : base(data)
        {
        }

        public override Command Create(string[] data)
        {
            return new AddTagCommand(data);
        }

        // AddTag <tag>
        public override void Execute()
        {
            string tag = base.data[1].ValidateOrTransform();

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var existsTag = context.Tags.FirstOrDefault(t => t.Name == tag);
                if (existsTag != null)
                {
                    throw new ArgumentException($"Tag [{tag}] exists!");
                }

                context.Tags.Add(new Tag
                {
                    Name = tag
                });

                context.SaveChanges();
            }

            Console.WriteLine(tag + " was added successfully to database!");
        }
    }
}
