namespace PhotographerSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum BackgroundColor
    {
        Red,
        Green,
        Black,
        Blue,
        Yellow,
        Purple,
        Brown,
        Aqua
    }

    public enum PublicOrPrivate
    {
        Public,
        Private
    }

    public class Album
    {
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
            this.Photographers = new HashSet<PhotographerAlbum>();
        }

        [Key]
        public int AlbumId { get; set; }

        [ForeignKey("Photographer")]
        public int? PhotographerId { get; set; }

        [Required]
        public string Name { get; set; }

        public BackgroundColor BackgroundColor { get; set; }

        public PublicOrPrivate PublicOrPrivate { get; set; }

        public virtual ICollection<PhotographerAlbum> Photographers { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

    }
}
