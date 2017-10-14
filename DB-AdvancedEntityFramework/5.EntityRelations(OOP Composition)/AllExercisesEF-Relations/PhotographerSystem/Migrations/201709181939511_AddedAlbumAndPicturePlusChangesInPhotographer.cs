namespace PhotographerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAlbumAndPicturePlusChangesInPhotographer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        PhotographerId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        BackgroundColor = c.Int(nullable: false),
                        PublicOrPrivate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Photographers", t => t.PhotographerId, cascadeDelete: true)
                .Index(t => t.PhotographerId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Caption = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.PictureId);
            
            CreateTable(
                "dbo.PictureAlbums",
                c => new
                    {
                        Picture_PictureId = c.Int(nullable: false),
                        Album_AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Picture_PictureId, t.Album_AlbumId })
                .ForeignKey("dbo.Pictures", t => t.Picture_PictureId, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId, cascadeDelete: true)
                .Index(t => t.Picture_PictureId)
                .Index(t => t.Album_AlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PictureAlbums", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.PictureAlbums", "Picture_PictureId", "dbo.Pictures");
            DropForeignKey("dbo.Albums", "PhotographerId", "dbo.Photographers");
            DropIndex("dbo.PictureAlbums", new[] { "Album_AlbumId" });
            DropIndex("dbo.PictureAlbums", new[] { "Picture_PictureId" });
            DropIndex("dbo.Albums", new[] { "PhotographerId" });
            DropTable("dbo.PictureAlbums");
            DropTable("dbo.Pictures");
            DropTable("dbo.Albums");
        }
    }
}
