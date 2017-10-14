namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBirthdateDirector : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Directors", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Directors", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
