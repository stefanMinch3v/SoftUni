namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class AddTagToCommand : Command
    {
        public AddTagToCommand(string[] data) 
            : base(data)
        {
        }

        // AddTagTo <albumName> <tag>
        public override void Execute()
        {
            string album = base.data[1];
            string tag = base.data[2];

            using (var context = new PhotoShareContext())
            {
                CheckTagAndAlbum(album, tag, context);

                var newTag = new Tag()
                {
                    Name = tag
                };

                context.Albums.First(a => a.Name == album).Tags.Add(newTag);
                context.SaveChanges();

                Console.WriteLine($"Tag [{tag}] added to [{album}]!");
            }
        }

        private static void CheckTagAndAlbum(string album, string tag, PhotoShareContext context)
        {
            using (context)
            {
                var contextTag = context.Tags.ToArray();
                var contextAlbum = context.Albums.ToArray();

                if (!contextTag.Any(t => t.Name == tag) || !contextAlbum.Any(a => a.Name == album))
                {
                    throw new ArgumentException($"Either tag or album do not exist!");
                }
            } 
        }

        public override Command Create(string[] data)
        {
            return new AddTagToCommand(data);
        }
    }
}
