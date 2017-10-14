namespace PhotographerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTagClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TagId, t.Name });
            
            CreateTable(
                "dbo.TagAlbums",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Tag_Name = c.String(nullable: false, maxLength: 128),
                        Album_AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Tag_Name, t.Album_AlbumId })
                .ForeignKey("dbo.Tags", t => new { t.Tag_TagId, t.Tag_Name }, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId, cascadeDelete: true)
                .Index(t => new { t.Tag_TagId, t.Tag_Name })
                .Index(t => t.Album_AlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagAlbums", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.TagAlbums", new[] { "Tag_TagId", "Tag_Name" }, "dbo.Tags");
            DropIndex("dbo.TagAlbums", new[] { "Album_AlbumId" });
            DropIndex("dbo.TagAlbums", new[] { "Tag_TagId", "Tag_Name" });
            DropTable("dbo.TagAlbums");
            DropTable("dbo.Tags");
        }
    }
}
