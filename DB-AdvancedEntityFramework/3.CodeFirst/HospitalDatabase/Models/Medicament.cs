namespace HospitalDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Medicament
    {
        public Medicament()
        {
            this.Patients = new List<Patient>();
        }

        [Key]
        public int MedicamentId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
