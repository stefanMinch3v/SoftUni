namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public enum CompetitionName
    {
        Local,
        National,
        International
    }

    public class CompetitionType
    {
        public CompetitionType()
        {
            this.Competitions = new HashSet<Competition>();
        }

        [Key]
        public int CompetitionTypeId { get; set; }

        /// <summary>
        /// Local = 0, National = 1, International = 2
        /// </summary>
        public CompetitionName Name { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }
    }
}
