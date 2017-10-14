namespace CodeFirstStudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum ResourceEnum
    {
        Video,
        Presentation,
        Document,
        Other
    }

    public class Resource
    {
        public Resource()
        {
            this.Licenses = new HashSet<License>();
        }

        //private string typeOfResource;

        public int ResourceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression("Video|Presentation|Document|Other", ErrorMessage = "Invalid type of resource!")]
        public string TypeOfResource { get; set; }

        [Required]
        public string Url { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; } //navigational property  - always nullable

        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}
