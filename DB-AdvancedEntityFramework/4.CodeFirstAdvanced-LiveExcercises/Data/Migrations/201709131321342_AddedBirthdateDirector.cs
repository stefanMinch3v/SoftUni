namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBirthdateDirector : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Directors", "DateOfBirth", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Directors", "DateOfBirth");
        }
    }
}
