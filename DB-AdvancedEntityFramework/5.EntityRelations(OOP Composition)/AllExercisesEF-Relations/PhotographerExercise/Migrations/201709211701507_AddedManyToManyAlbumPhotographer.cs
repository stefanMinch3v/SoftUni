namespace PhotographerExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManyToManyAlbumPhotographer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "PhotographerId", "dbo.Photographers");
            DropIndex("dbo.Albums", new[] { "PhotographerId" });
            CreateTable(
                "dbo.PhotographerAlbums",
                c => new
                    {
                        Photographer_PhotographerId = c.Int(nullable: false),
                        Album_AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Photographer_PhotographerId, t.Album_AlbumId })
                .ForeignKey("dbo.Photographers", t => t.Photographer_PhotographerId, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId, cascadeDelete: true)
                .Index(t => t.Photographer_PhotographerId)
                .Index(t => t.Album_AlbumId);
            
            DropColumn("dbo.Albums", "PhotographerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "PhotographerId", c => c.Int());
            DropForeignKey("dbo.PhotographerAlbums", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.PhotographerAlbums", "Photographer_PhotographerId", "dbo.Photographers");
            DropIndex("dbo.PhotographerAlbums", new[] { "Album_AlbumId" });
            DropIndex("dbo.PhotographerAlbums", new[] { "Photographer_PhotographerId" });
            DropTable("dbo.PhotographerAlbums");
            CreateIndex("dbo.Albums", "PhotographerId");
            AddForeignKey("dbo.Albums", "PhotographerId", "dbo.Photographers", "PhotographerId");
        }
    }
}
