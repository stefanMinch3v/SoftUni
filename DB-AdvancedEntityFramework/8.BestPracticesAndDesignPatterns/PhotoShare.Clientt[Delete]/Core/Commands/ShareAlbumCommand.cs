namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class ShareAlbumCommand : Command
    {
        public ShareAlbumCommand(string[] data) 
            : base(data)
        {
        }

        public override Command Create(string[] data)
        {
            return new ShareAlbumCommand(data);
        }

        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public override void Execute()
        {
            int albumId = int.Parse(base.data[1]);
            string username = base.data[2];
            string permission = base.data[3];

            using (var context = new PhotoShareContext())
            {
                if (!context.Albums.Any(a => a.Id == albumId))
                {
                    throw new ArgumentException($"Album [{albumId}] not found!");
                }

                if (!context.Users.Any(u => u.Username == username))
                {
                    throw new ArgumentException($"User [{username}] not found!");
                }

                Role role;
                if (!Enum.TryParse(permission, out role))
                {
                    throw new ArgumentException($"Permission must be either “Owner” or “Viewer”!");
                }

                //todo connection

            }
        }
    }
}
