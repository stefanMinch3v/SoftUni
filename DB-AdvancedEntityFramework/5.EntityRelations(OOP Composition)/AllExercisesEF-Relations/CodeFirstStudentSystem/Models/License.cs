namespace CodeFirstStudentSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class License
    {
        [Key]
        public int LicenseId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Resource")]
        public int ResourceId { get; set; }

        public virtual Resource Resource { get; set; }
    }
}
