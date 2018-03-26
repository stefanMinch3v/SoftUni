namespace CarDealer.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CarDealerDbContext : IdentityDbContext<User>
    {
        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Logger> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Supplier>()
                .HasMany(s => s.Parts)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId);

            builder
                .Entity<Part>()
                .HasMany(p => p.Cars)
                .WithOne(c => c.Part)
                .HasForeignKey(c => c.PartId);

            builder
                .Entity<Car>()
                .HasMany(c => c.Parts)
                .WithOne(p => p.Car)
                .HasForeignKey(p => p.CarId);

            builder
                .Entity<Car>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Car)
                .HasForeignKey(s => s.CarId);

            builder
                .Entity<PartCar>()
                .HasKey(k => new { k.CarId, k.PartId });

            builder
                .Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId);

            base.OnModelCreating(builder);
        }
    }
}
