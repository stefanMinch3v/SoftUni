namespace AspCoreOverallInfo.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CatTestModel
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "The name must be max 15 symbols long.")]
        public string Name { get; set; }
    }
}
