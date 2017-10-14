namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        public Game()
        {
            this.BetGames = new HashSet<BetGame>();
        }

        [Key]
        public int GameId { get; set; }

        [ForeignKey("HomeTeam")]
        public int? HomeTeamId { get; set; }

        [ForeignKey("AwayTeam")]
        public int? AwayTeamId { get; set; }

        [ForeignKey("Round")]
        public int? RoundId { get; set; }

        [ForeignKey("Competition")]
        public int? CompetitionId { get; set; }

        public virtual Team HomeTeam { get; set; }

        public virtual Team AwayTeam { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public DateTime DateAndTimeOfGames { get; set; }

        public float HomeTeamWinBetRate { get; set; }

        public float AwayTeamWinBetRate { get; set; }

        public float DrawGameBetRate { get; set; }

        public virtual Round Round { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual ICollection<BetGame> BetGames { get; set; }

    }
}
