using System.Data.Entity;

namespace Data
{
    public class MyInit : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.MyModel.Add(new MyModel { Name = "Ivan" });
            context.SaveChanges();
        }
    }
}
