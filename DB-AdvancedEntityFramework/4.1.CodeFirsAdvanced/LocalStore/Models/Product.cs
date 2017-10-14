namespace Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string DistributorName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public float? Weight { get; set; }

        public int? Quantity { get; set; }
    }
}
