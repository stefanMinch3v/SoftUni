namespace PhotographerExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        PhotographerId = c.Int(),
                        Name = c.String(nullable: false),
                        BackgroundColor = c.Int(nullable: false),
                        PublicOrPrivate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Photographers", t => t.PhotographerId)
                .Index(t => t.PhotographerId);
            
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
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
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
            
            CreateTable(
                "dbo.TagAlbums",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Album_AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Album_AlbumId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Album_AlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagAlbums", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.TagAlbums", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.PictureAlbums", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.PictureAlbums", "Picture_PictureId", "dbo.Pictures");
            DropForeignKey("dbo.Albums", "PhotographerId", "dbo.Photographers");
            DropIndex("dbo.TagAlbums", new[] { "Album_AlbumId" });
            DropIndex("dbo.TagAlbums", new[] { "Tag_TagId" });
            DropIndex("dbo.PictureAlbums", new[] { "Album_AlbumId" });
            DropIndex("dbo.PictureAlbums", new[] { "Picture_PictureId" });
            DropIndex("dbo.Albums", new[] { "PhotographerId" });
            DropTable("dbo.TagAlbums");
            DropTable("dbo.PictureAlbums");
            DropTable("dbo.Tags");
            DropTable("dbo.Pictures");
            DropTable("dbo.Photographers");
            DropTable("dbo.Albums");
        }
    }
}
