namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        //•	Products have an id, name (at least 3 characters), price, buyerId (optional) and sellerId as IDs of users.
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 1000, MinimumLength = 3)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        //[ForeignKey("Buyer")]
        public int? BuyerId { get; set; }

        //[ForeignKey("Seller")]
        public int SellerId { get; set; }

        //[InverseProperty("BoughtProducts")]
        public virtual User Buyer { get; set; }

        //[InverseProperty("SoldProducts")]
        public virtual User Seller { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
