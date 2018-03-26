namespace CameraBazaar.Services
{
    using Data.Models;
    using Data.Models.Enums;
    using Models.Cameras;
    using System.Collections.Generic;

    public interface ICameraService
    {
        void Create(
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
            IEnumerable<LightMetering> lightMetering,
            string description,
            string imageUrl,
            string userId
        );

        void Edit(
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
            string imageUrl);

        IEnumerable<CameraListModel> All();

        CameraDetailsModel ById(int id);

        IEnumerable<Camera> ByUserId(string id);

        bool Existing(int id, string userId);

        bool ExistingById(int id);

        void Delete(int id);
    }
}
