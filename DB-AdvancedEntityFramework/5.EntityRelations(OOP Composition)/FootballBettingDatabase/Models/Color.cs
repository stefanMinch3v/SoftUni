namespace Models
{
    using System.ComponentModel.DataAnnotations;

    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
