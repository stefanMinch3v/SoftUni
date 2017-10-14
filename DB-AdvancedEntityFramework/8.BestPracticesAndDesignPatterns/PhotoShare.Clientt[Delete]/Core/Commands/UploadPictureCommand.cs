namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class UploadPictureCommand : Command
    {
        public UploadPictureCommand(string[] data)
            : base(data)
        {
        }

        public override Command Create(string[] data)
        {
            return new UploadPictureCommand(data);
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public override void Execute()
        {
            string album = base.data[1];
            string pictureTitle = base.data[2];
            string path = base.data[3];

            using (var context = new PhotoShareContext())
            {
                if (!context.Albums.Any(a => a.Name == album))
                {
                    throw new ArgumentException($"Album [{album}] not found!");
                }

                var picture = new Picture()
                {
                    Title = pictureTitle,
                    Path = path
                };

                context.Albums.First(a => a.Name == album).Pictures.Add(picture);
                context.SaveChanges();

                Console.WriteLine($"Picture [{pictureTitle}] added to [{album}]!");
            }
        }
    }
}
