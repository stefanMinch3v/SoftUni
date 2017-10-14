namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Models;
    using PhotoShare.Service;
    using System;
    using Attributes;

    [Command("ShareAlbum")]
    public class ShareAlbumCommand : Command
    {
        private readonly AlbumService albumService;
        private readonly UserService userService;

        public ShareAlbumCommand(AlbumService albumService, UserService userService)
        {
            this.albumService = albumService;
            this.userService = userService;
        }

        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public override string Execute()
        {
            int albumId = int.Parse(data[0]);
            string username = data[1];
            string permission = data[2];

            var album = this.albumService.FindAlbumById(albumId);
            if (album == null)
            {
                throw new ArgumentException($"Album [{albumId}] not found!");
            }

            if (!SecurityService.Instance.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (!this.albumService.IsUserOwnerOfAlbum(SecurityService.Instance.GetCurrentUser().Username, album.Name))
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (!this.userService.IsUserExisting(username))
            {
                throw new ArgumentException($"User [{username}] not found!");
            }

            if (!Enum.TryParse(permission, out Role role))
            {
                throw new ArgumentException($"Permission must be either “Owner” or “Viewer”!");
            }

            Role currentPermission = (Role)Enum.Parse(typeof(Role), permission);
            var user = this.userService.GetUserByUsername(username);

            this.albumService.ShareAlbum(user, album, currentPermission);

            return ($"Username [{username}] added to album [{album.Name}] ([{permission}])");
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
