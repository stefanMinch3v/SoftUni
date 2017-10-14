namespace UI
{
    using System.Collections;
    using System;
    using Data;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var context = new SalesContext();
            //context.Database.Initialize(true);
        }
    }
}
