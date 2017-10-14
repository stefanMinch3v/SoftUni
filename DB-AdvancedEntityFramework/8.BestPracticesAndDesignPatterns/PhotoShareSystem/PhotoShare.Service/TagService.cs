namespace PhotoShare.Service
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System.Linq;

    public class TagService
    {
        public void AddTag(string tag)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Tags.Add(new Tag()
                {
                    Name = tag
                });

                context.SaveChanges();
            }
        }

        public bool IsTagExisting(string tag)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Tags.Any(t => t.Name == tag);
            }
        }

        public void AddTagTo(string albumName, string tagName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var currentTag = context.Tags.First(t => t.Name == tagName);

                var currentAlbum = context.Albums.First(a => a.Name == albumName);

                currentAlbum.Tags.Add(currentTag);

                context.SaveChanges();
            }
        }
    }
}
