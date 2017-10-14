using System.Linq;

namespace Data
{
    public class Repo
    {
        public static string GetData()
        {
            using (var context = new DataContext())
            {
                //context.Database.Initialize(true);

                return context.MyModel.First().Name;
            }
        }
    }
}
