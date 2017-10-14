namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public enum EnumPrediction
    {
        HomeTeamWin,
        DrawGame,
        AwayTeamWin
    }

    public class ResultPrediction
    {
        public ResultPrediction()
        {
            this.BetGames = new HashSet<BetGame>();
        }

        [Key]
        public int PredictionId { get; set; }

        /// <summary>
        /// Possible values - Home Team Win = 0, Draw Game = 1, Away Team Win = 2
        /// </summary>
        public EnumPrediction Prediction { get; set; }

        public virtual ICollection<BetGame> BetGames { get; set; }
    }
}
