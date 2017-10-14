namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Player
    {
        public Player()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistics>();
            //this.Positions = new HashSet<Position>();
        }

        [Key]
        public int PlayerId { get; set; }

        [ForeignKey("Team")]
        public int? TeamId { get; set; }

        //[ForeignKey("Position")]
        public string PositionId { get; set; }

        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public virtual Team Team { get; set; }

        //public virtual ICollection<Position> Positions { get; set; }

        public virtual Position Position { get; set; }

        public bool IsCurrentlyInjured { get; set; }

        public virtual ICollection<PlayerStatistics> PlayerStatistics { get; set; }

    }
}
