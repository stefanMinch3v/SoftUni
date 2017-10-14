namespace BookLy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookModelAddition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Summary = c.String(),
                        Pages = c.Int(nullable: false),
                        ContentSource = c.String(),
                        AuthorId = c.String(maxLength: 128),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Books");
        }
    }
}
