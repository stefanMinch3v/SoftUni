namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class StoreLocation
    {
        public StoreLocation()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int StoreLocationId { get; set; }

        [Required]
        public string LocationName { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}