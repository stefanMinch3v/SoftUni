namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Utilities;
    using PhotoShare.Models;
    using PhotoShare.Service;
    using System;
    using System.Linq;
    using Attributes;

    [Command("CreateAlbum")]
    public class CreateAlbumCommand : Command
    {
        private readonly AlbumService albumService;
        private readonly UserService userService;
        private readonly TagService tagService;

        public CreateAlbumCommand(AlbumService albumService, UserService userService, TagService tagService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.tagService = tagService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public override string Execute()
        {
            string username = data[0];
            string albumTitle = data[1];
            string bgColor = data[2];

            var user = this.userService.GetUserByUsername(username);

            if (user == null)
            {
                throw new ArgumentException($"User [{username}] not found!");
            }

            if (this.albumService.IsAlbumExisting(albumTitle))
            {
                throw new ArgumentException($"Album [{albumTitle}] exists!");
            }

            if (!SecurityService.Instance.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (SecurityService.Instance.GetCurrentUser().Username != username)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (!Enum.TryParse(bgColor, out Color colorr))
            {
                throw new ArgumentException($"Color [{bgColor}] not found!");
            }

            Color color = (Color)Enum.Parse(typeof(Color), bgColor);

            var tags = data.Skip(3).Select(t => TagUtilities.ValidateOrTransform(t)).ToArray();

            foreach (var tag in tags)
            {
                if (!this.tagService.IsTagExisting(tag))
                {
                    throw new ArgumentException($"Invalid tags!");
                }
            }

            this.albumService.AddAlbum(user, albumTitle, color, tags);

            return ($"Album [{albumTitle}] successfully created!");
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
