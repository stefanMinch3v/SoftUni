using System.Collections.Generic;

namespace Models
{
    public class Movie
    {
        public Movie()
        {
            this.Actors = new HashSet<Actor>();
            this.Genres = new HashSet<Genre>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        //public string Genre { get; set; }

        public int YearOfRelease { get; set; }

        public float Rating { get; set; }

        public int DirectorId { get; set; }
        
        public int DurationInMinutes { get; set; }

        public virtual Director Director { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
