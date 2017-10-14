﻿
namespace RelicFinder.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Relic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        [NotMapped]
        public bool IsDirty { get; set; }
    }
}
