namespace CarDealer.Services.Models
{

    using System;

    public class LoggerModel
    {
        public string Username { get; set; }

        public string Operation { get; set; }

        public string ModifiedTable { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
