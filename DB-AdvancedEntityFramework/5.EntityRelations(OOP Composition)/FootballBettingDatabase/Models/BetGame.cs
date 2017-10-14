namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BetGame
    {
        //Game, Bet, Result Prediction (PK = Game + Bet)
        [Key]
        [Column(Order = 1)]
        public int GameId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int BetId { get; set; }

        [ForeignKey("ResultPrediction")]
        public int? ResultPredictionId { get; set; }

        public virtual ResultPrediction ResultPrediction { get; set; }

        public virtual Game Game { get; set; }

        public virtual Bet Bet{ get; set; }

    }
}
