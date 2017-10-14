namespace HospitalDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Visitation
    {
        public Visitation()
        {
            this.Patients = new List<Patient>();
        }

        [Key]
        public int VisitationId { get; set; }

        [Required]
        public DateTime DateOfVisit{ get; set; }

        [Required]
        [MinLength(6)]
        public string Comment { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
