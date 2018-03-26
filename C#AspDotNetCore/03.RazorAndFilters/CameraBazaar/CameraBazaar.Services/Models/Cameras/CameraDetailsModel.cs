namespace CameraBazaar.Services.Models.Cameras
{
    using Data.Models.Enums;

    public class CameraDetailsModel : CameraListModel
    {
        public int MinShutterSpeed { get; set; }

        public int MaxShutterSpeed { get; set; }

        public MinISO MinISO { get; set; }

        public int MaxISO { get; set; }

        public bool IsFullFrame { get; set; }

        public string VideoResolution { get; set; }

        public LightMetering LightMetering { get; set; }

        public string Description { get; set; }

        public string Username { get; set; }

        public string UserId { get; set; }
    }
}
