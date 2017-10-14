namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }

        [MaxLength(2)]
        public string PositionID { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Player> Players { get; set; }

    }
}
