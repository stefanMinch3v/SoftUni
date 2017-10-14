namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTestMigrationColumnInDirector : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieDuration", c => c.Int(nullable: true));
            AddColumn("dbo.Directors", "TestThisFuckingMigration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Directors", "TestThisFuckingMigration");
            DropColumn("dbo.Movies", "MovieDuration");
        }
    }
}
