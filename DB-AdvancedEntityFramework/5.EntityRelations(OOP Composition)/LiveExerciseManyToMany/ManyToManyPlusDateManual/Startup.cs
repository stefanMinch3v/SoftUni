namespace ManyToManyPlusDateManual
{
    using ManyToManyPlusDateManual.Data;
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args) 
        {
            var context = new EmployeeContext();
            context.Database.Initialize(true);

        }
    }
}
