namespace HospitalDatabase
{
    using Models;
    using System;
    using System.Data.Entity;

    public class Startup
    {
        public static void Main()
        {
            var context = new HospitalContext();
            //context.Database.Initialize(true);

            var patient = new Patient()
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Address = "Struma 2432, Kiten",
                DateOfBirth = DateTime.Parse("01-10-1980"),
                Email = "hitrec@abv.bg",
                MedicalInsrance = true,
            };

            var diagnose = new Diagnose()
            {
                Comment = "very ill",
                Name = "Varicela"
            };

            var medicament = new Medicament()
            {
                Name = "Antibiotik"
            };

            context.Patients.Add(patient);
            context.Diagnoses.Add(diagnose);
            context.Medicaments.Add(medicament);

            context.SaveChanges();

        }
    }
}
