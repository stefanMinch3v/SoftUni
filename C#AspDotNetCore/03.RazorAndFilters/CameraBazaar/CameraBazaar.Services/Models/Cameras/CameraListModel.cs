namespace CameraBazaar.Services.Models.Cameras
{
    using Data.Models.Enums;

    public class CameraListModel
    {
        public int Id { get; set; }

        public CameraMakeType Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }
    }
}
