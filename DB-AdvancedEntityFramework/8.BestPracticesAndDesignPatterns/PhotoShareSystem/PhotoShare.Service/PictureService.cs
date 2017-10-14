namespace PhotoShare.Service
{
    using PhotoShare.Data;
    using PhotoShare.Models;

    public class PictureService
    {
        public void UploadPicture(Album album, string pictureTitle, string picturePath)
        {
            using (var context = new PhotoShareContext())
            {
                var picture = new Picture()
                {
                    Title = pictureTitle,
                    Path = picturePath,
                };

                picture.Albums.Add(album);

                context.Albums.Attach(album);
                album.Pictures.Add(picture);
                
                context.Entry(album).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
