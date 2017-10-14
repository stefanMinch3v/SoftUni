namespace CodeFirstStudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum HomeworkEnum
    {
        Application,
        Pdf,
        Zip
    }

    public class Homework
    {
        private string contentType;

        public Homework()// exception
        {
        }

        public Homework(string contentType)
        {
            this.ContentType = contentType;
        }

        public int HomeworkId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ContentType
        {
            get
            {
                return this.contentType;
            }
            private set
            {
                if (!Enum.IsDefined(typeof(HomeworkEnum), value))
                {
                    throw new ArgumentException("Invalid type of homework! Allowed only Pdf, Zip or Application");
                }

                this.contentType = value;
            }
        }

        [Required]
        public DateTime SubmissionDate { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; } //navigational property - always nullable

        [ForeignKey("Student")]
        public int? StudentId { get; set; } //navigational property - always nullable

        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }
    }
}
