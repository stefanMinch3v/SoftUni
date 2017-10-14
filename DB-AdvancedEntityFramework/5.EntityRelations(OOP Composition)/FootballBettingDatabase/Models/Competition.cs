namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Competition
    {
        public Competition()
        {
            this.Games = new HashSet<Game>();
        }

        [Key]
        public int CompetitionId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual CompetitionType Type { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
