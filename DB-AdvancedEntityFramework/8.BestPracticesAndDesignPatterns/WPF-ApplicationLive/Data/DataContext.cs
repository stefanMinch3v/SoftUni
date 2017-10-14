namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
            Database.SetInitializer(new MyInit());
        }

        public virtual DbSet<MyModel> MyModel { get; set; }
    }
}