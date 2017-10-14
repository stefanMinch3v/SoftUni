namespace HospitalDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Diagnose
    {
        public Diagnose()
        {
            this.Patients = new List<Patient>();
        }

        [Key]
        public int DiagnoseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(6)]
        public string Comment { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
