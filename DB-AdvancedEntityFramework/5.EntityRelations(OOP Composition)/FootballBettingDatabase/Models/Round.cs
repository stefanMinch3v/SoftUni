namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Round
    {
        public Round()
        {
            this.Games = new HashSet<Game>();
        }

        [Key]
        public int RoundId { get; set; }

        /// <summary>
        /// for example Groups, League, 1/8 Final, 1/4 Final, Semi-Final, Final…
        /// </summary>
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
