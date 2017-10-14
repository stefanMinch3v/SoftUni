namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public decimal Money { get; set; }

        public DateTime DateAndTimeOfBet { get; set; }

        public virtual User User { get; set; }
    }
}
