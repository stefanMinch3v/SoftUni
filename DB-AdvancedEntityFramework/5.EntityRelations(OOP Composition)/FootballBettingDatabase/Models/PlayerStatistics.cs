namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayerStatistics
    {
        [Key]
        [Column(Order = 1)]
        public int GameId { get; set; }
        
        [Key]
        [Column(Order = 2)]
        public int PlayerId{ get; set; }

        public virtual Game Game { get; set; }

        public virtual Player Player { get; set; }

        public int ScoredGoals { get; set; }

        public string PlayerAssists { get; set; }

        public float PlayedMinutesDuringGame { get; set; }
    }
}
