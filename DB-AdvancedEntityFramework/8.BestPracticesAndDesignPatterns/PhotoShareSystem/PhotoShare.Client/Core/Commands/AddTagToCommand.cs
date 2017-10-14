namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Utilities;
    using PhotoShare.Service;
    using System;
    using Attributes;

    [Command("AddTagTo")]
    public class AddTagToCommand : Command
    {
        private readonly TagService tagService;
        private readonly AlbumService albumService;

        public AddTagToCommand(TagService tagService, AlbumService albumService)
        {
            this.tagService = tagService;
            this.albumService = albumService;
        }

        // AddTagTo <albumName> <tag>
        public override string Execute()
        {
            string album = data[0];
            string tag = data[1];

            tag = TagUtilities.ValidateOrTransform(tag);

            if (!this.tagService.IsTagExisting(tag) || !this.albumService.IsAlbumExisting(album))
            {
                throw new ArgumentException($"Either tag or album do not exist!");
            }

            if (!SecurityService.Instance.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (!this.albumService.IsUserOwnerOfAlbum(SecurityService.Instance.GetCurrentUser().Username, album))
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            this.tagService.AddTagTo(album, tag);

            return (($"Tag [{tag}] added to [{album}]!"));
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
