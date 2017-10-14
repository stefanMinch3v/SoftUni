namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDurationInMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DurationInMinutes", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DurationInMinutes");
        }
    }
}
