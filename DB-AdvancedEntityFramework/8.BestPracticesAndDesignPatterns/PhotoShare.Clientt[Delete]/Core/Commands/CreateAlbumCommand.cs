namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateAlbumCommand : Command
    {
        public CreateAlbumCommand(string[] data) 
            : base(data)
        {
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public override void Execute()
        {
            string username = data[1];
            string albumTitle = data[2];
            string bgColor = data[3];
            var tags = data.Skip(4).ToArray();
            List<Tag> allTags = new List<Tag>();

            using (var context = new PhotoShareContext())
            {
                CheckUsername(username, context);
                CheckAlbums(albumTitle, context);
                CheckColor(bgColor);
                CheckTags(tags, context);

                foreach (var tag in tags)
                {
                    var newTag = new Tag()
                    {
                        Name = tag
                    };

                    allTags.Add(newTag);
                }

                var currentAlbum = new Album()
                {
                    Name = albumTitle,
                    BackgroundColor = (Color)Enum.Parse(typeof(Color), bgColor),
                    Tags = allTags
                };

                Console.WriteLine($"Album [{albumTitle}] successfully created!");
            }
        }

        private static void CheckTags(string[] tags, PhotoShareContext context)
        {
            using (context)
            {
                var contextTags = context.Tags.ToArray();
                foreach (var tagg in tags)
                {
                    if (!context.Tags.Any(t => t.Name == tagg))
                    {
                        throw new ArgumentException($"Invalid tags!");
                    }
                }
            }
            
        }

        private static void CheckColor(string bgColor)
        {
            Color color;
            if (!Enum.TryParse(bgColor, out color))
            {
                throw new ArgumentException($"Color [{bgColor}] not found!");
            }
        }

        private static void CheckAlbums(string albumTitle, PhotoShareContext context)
        {
            using (context)
            {
                if (context.Albums.Any(a => a.Name == albumTitle))
                {
                    throw new ArgumentException($"Album [{albumTitle}] exists!");
                }
            }
            
        }

        private static void CheckUsername(string username, PhotoShareContext context)
        {
            using (context)
            {
                if (!context.Users.Any(u => u.Username == username))
                {
                    throw new ArgumentException($"User [{username}] not found!");
                }
            }
            
        }

        public override Command Create(string[] data)
        {
            return new CreateAlbumCommand(data);
        }
    }
}
