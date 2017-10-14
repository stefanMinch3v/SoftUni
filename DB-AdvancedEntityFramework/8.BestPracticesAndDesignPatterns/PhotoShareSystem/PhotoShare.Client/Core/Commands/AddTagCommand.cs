namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Service;
    using System;
    using Utilities;
    using Attributes;

    [Command("AddTag")]
    public class AddTagCommand : Command
    {
        private readonly TagService tagService;

        public AddTagCommand(TagService tagService) 
        {
            this.tagService = tagService;
        }

        public override string Execute()
        {
            string tag = TagUtilities.ValidateOrTransform(data[0]);

            if (this.tagService.IsTagExisting(tag))
            {
                throw new ArgumentException($"Tag [{tag}] exists!");
            }

            if (SecurityService.Instance.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            this.tagService.AddTag(tag);

            return (tag + " was added successfully to database!");
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
