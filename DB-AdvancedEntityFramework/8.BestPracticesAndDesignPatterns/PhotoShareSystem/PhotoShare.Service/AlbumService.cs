namespace PhotoShare.Service
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System.Linq;

    public class AlbumService
    {
        public void AddAlbum(User user, string albumName, Color color, string[] tags)
        {
            using (var context = new PhotoShareContext())
            {
                var currentAlbum = new Album()
                {
                    Name = albumName,
                    BackgroundColor = color
                };

                foreach (var tag in tags)
                {
                    var currentTag = context.Tags.First(t => t.Name == tag);

                    currentAlbum.Tags.Add(currentTag);
                }

                context.Albums.Add(currentAlbum);

                context.Users.Attach(user);

                AlbumRole albumRole = new AlbumRole()
                {
                    Album = currentAlbum,
                    User = user,
                    Role = Role.Owner
                };

                context.Entry(user).State = System.Data.Entity.EntityState.Modified;

                currentAlbum.AlbumRoles.Add(albumRole);
                context.SaveChanges();
            }
        }

        public bool IsAlbumExisting(string albumName)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Albums.Any(u => u.Name == albumName);
            }
        }

        public Album FindAlbumById(int albumId)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Albums.FirstOrDefault(a => a.Id == albumId);
            }
        }

        public void ShareAlbum(User user, Album album, Role permission)
        {
            using (var context = new PhotoShareContext())
            {
                var albumRole = new AlbumRole()
                {
                    Album = album,
                    User = user,
                    Role = permission
                };

                context.Users.Attach(user);
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;

                context.Albums.Attach(album);
                context.Entry(album).State = System.Data.Entity.EntityState.Modified;

                context.AlbumRoles.Add(albumRole);
                context.SaveChanges();
            }
        }

        public Album FindAlbumByName(string albumName)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Albums.SingleOrDefault(a => a.Name == albumName);
            }
        }

        public bool IsUserOwnerOfAlbum(string username, string albumName)
        {
            using (var context = new PhotoShareContext())
            {
                Album album = context.Albums
                                            .Include("AlbumRoles")
                                            .Include("AlbumRoles.User")
                                            .SingleOrDefault(a => a.Name == albumName);
                if (album == null)
                {
                    return false;
                }

                return album.AlbumRoles.Any(ar => ar.User.Username == username && ar.Role == Role.Owner);
            }
        }
    }
}
