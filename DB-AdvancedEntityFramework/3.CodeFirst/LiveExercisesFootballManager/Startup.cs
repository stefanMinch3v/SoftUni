namespace LiveExercisesFootballManager
{
    using Models;
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            //var context = new FootballManagerContext();
            //context.Database.Initialize(true); to create the tables in the DB master
            var fmContext = new FMContext();
            //fmContext.Database.Initialize(true);
            fmContext.Teams.Add(new Team() { Name = "Barcelona"});
            fmContext.SaveChanges();

        }
    }
}
