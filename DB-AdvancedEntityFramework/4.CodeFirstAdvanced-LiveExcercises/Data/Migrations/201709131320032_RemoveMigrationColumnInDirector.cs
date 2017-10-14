namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMigrationColumnInDirector : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Directors", "TestThisFuckingMigration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Directors", "TestThisFuckingMigration", c => c.String());
        }
    }
}
