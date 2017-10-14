namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDurationMovies : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "DurationInMinutes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "DurationInMinutes", c => c.Int(nullable: false));
        }
    }
}
