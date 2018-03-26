namespace CameraBazaar.Services.Implementations
{
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using System.Collections.Generic;
    using System.Linq;
    using CameraBazaar.Services.Models.Cameras;

    public class CameraService : ICameraService
    {
        private readonly BazaarDbContext db;

        public CameraService(BazaarDbContext db)
        {
            this.db = db;
        }

        public void Create(
            CameraMakeType make, 
            string model, 
            decimal price, 
            int quantity, 
            int minShutterSpeed, 
            int maxShutterSpeed, 
            MinISO minIso, 
            int maxIso,
            bool isFullFrame, 
            string videoResolution,
            IEnumerable<LightMetering> lightMeterings,
            string description, 
            string imageUrl,
            string userId
        )
        {
            var camera = new Camera
            {
                Make = make,
                Model = model,
                Price = price,
                Quantity = quantity,
                MinShutterSpeed = minShutterSpeed,
                MaxShutterSpeed = maxShutterSpeed,
                MinISO = minIso,
                MaxISO = maxIso,
                IsFullFrame = isFullFrame,
                VideoResolution = videoResolution,
                LightMetering = (LightMetering)lightMeterings.Cast<int>().Sum(),
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Cameras.Add(camera);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var camera = this.db.Cameras.Find(id);

            if (camera == null)
            {
                return;
            }

            this.db.Cameras.Remove(camera);
            this.db.SaveChanges();
        }

        public void Edit(
            int id,
            CameraMakeType make,
            string model,
            decimal price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            MinISO minIso,
            int maxIso,
            bool isFullFrame,
            string videoResolution,
            IEnumerable<LightMetering> lightMeterings,
            string description,
            string imageUrl)
        {
            var camera = this.db.Cameras.Find(id);

            if (camera == null)
            {
                return; // return false
            }

            camera.Make = make;
            camera.Model = model;
            camera.Price = price;
            camera.Quantity = quantity;
            camera.MinShutterSpeed = minShutterSpeed;
            camera.MaxShutterSpeed = maxShutterSpeed;
            camera.MinISO = minIso;
            camera.MaxISO = maxIso;
            camera.IsFullFrame = isFullFrame;
            camera.VideoResolution = videoResolution;
            camera.LightMetering = (LightMetering)lightMeterings.Cast<int>().Sum();
            camera.Description = description;
            camera.ImageUrl = imageUrl;

            this.db.Cameras.Update(camera);
            this.db.SaveChanges();
        }

        public IEnumerable<CameraListModel> All()
            => this.db.Cameras
                .OrderByDescending(c => c.Id)
                .Select(c => new CameraListModel
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    ImageUrl = c.ImageUrl
                })
                .ToList();

        public CameraDetailsModel ById(int id)
            => this.db.Cameras
                .Where(c => c.Id == id)
                .Select(c => new CameraDetailsModel
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    ImageUrl = c.ImageUrl,
                    MinShutterSpeed = c.MinShutterSpeed,
                    MaxShutterSpeed = c.MaxShutterSpeed,
                    MinISO = c.MinISO,
                    MaxISO = c.MaxISO,
                    IsFullFrame = c.IsFullFrame,
                    VideoResolution = c.VideoResolution,
                    LightMetering = c.LightMetering,
                    Description = c.Description,
                    Username = c.User.UserName,
                    UserId = c.UserId
                })
                .FirstOrDefault();

        public IEnumerable<Camera> ByUserId(string id)
            => this.db.Cameras
                .Where(c => c.UserId == id)
                .ToList();

        public bool Existing(int id, string userId)
            => this.db.Cameras.Any(c => c.Id == id && c.UserId == userId);

        public bool ExistingById(int id)
            => this.db.Cameras.Any(c => c.Id == id);
    }
}
