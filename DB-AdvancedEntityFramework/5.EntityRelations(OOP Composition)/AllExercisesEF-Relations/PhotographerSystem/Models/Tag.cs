namespace PhotographerSystem.Models
{
    using PhotographerSystem.Attributes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tag
    {
        public Tag()
        {
            this.Albums = new HashSet<Album>();
        }

        [Key]
        [Column(Order = 1)]
        public int TagId { get; set; }

        [Key]
        [Column(Order = 2)]
        //[Tag]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
