namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Service;
    using System;
    using Attributes;

    [Command("UploadPicture")]
    public class UploadPictureCommand : Command
    {
        private readonly PictureService pictureService;
        private readonly AlbumService albumService;

        public UploadPictureCommand(PictureService pictureService, AlbumService albumService)
        {
            this.pictureService = pictureService;
            this.albumService = albumService;
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public override string Execute()
        {
            string album = data[0];
            string pictureTitle = data[1];
            string path = data[2];

            var currentAlbum = this.albumService.FindAlbumByName(album) ?? throw new ArgumentException($"Album [{album}] not found!");

            if (!SecurityService.Instance.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (!this.albumService.IsUserOwnerOfAlbum(SecurityService.Instance.GetCurrentUser().Username, album))
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            this.pictureService.UploadPicture(currentAlbum, pictureTitle, path);

            return ($"Picture [{pictureTitle}] added to [{album}]!");
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
