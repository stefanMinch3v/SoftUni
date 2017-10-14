namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        [Key]
        public int TeamId { get; set; }

        [ForeignKey("Town")]
        public int? TownId { get; set; }

        [ForeignKey("PrimaryKitColor")]
        public int? PrimaryKitColorId { get; set; }

        [ForeignKey("SecondaryKitColor")]
        public int? SecondaryKitColorId { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }

        [MaxLength(3, ErrorMessage = "Allowed maximum 3 letters long initials")]
        public string Initials { get; set; }

        public virtual Color PrimaryKitColor { get; set; }

        public virtual Color SecondaryKitColor { get; set; }

        public virtual Town Town { get; set; }

        public decimal Budget { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
