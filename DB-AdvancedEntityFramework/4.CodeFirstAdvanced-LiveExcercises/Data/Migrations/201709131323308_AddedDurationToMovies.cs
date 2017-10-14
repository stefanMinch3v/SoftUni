namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDurationToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DurationInMinutes", c => c.Int(nullable: true));
            DropColumn("dbo.Movies", "MovieDuration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "MovieDuration", c => c.Int(nullable: true));
            DropColumn("dbo.Movies", "DurationInMinutes");
        }
    }
}
