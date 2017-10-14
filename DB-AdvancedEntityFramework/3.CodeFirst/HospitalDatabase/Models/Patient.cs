namespace HospitalDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Patient
    {
        public Patient()
        {
            this.Medicaments = new List<Medicament>();
            this.Diagnoses = new List<Diagnose>();
            this.Visitations = new List<Visitation>();
        }

        [Key]
        public int PatientId { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [MinLength(6)]
        public string Address { get; set; }

        [RegularExpression("@{1}")]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(1024*1024)]
        public byte[] Picture { get; set; }

        [Required]
        public bool MedicalInsrance { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<Medicament> Medicaments { get; set; }
    }
}
