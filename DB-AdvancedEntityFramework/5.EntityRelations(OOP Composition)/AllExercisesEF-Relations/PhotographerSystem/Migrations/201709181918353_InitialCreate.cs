namespace PhotographerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photographers",
                c => new
                    {
                        PhotographerId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        DateOfBirth = c.DateTime(),
                    })
                .PrimaryKey(t => t.PhotographerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Photographers");
        }
    }
}
