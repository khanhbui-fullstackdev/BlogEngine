namespace BlogEngine.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_BlogEngine_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Slug = c.String(maxLength: 255, unicode: false),
                        Image = c.String(maxLength: 255, unicode: false),
                        Summary = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        UserName = c.String(nullable: false, maxLength: 300, unicode: false),
                        Content = c.String(nullable: false, maxLength: 4000),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        PostID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Slug = c.String(maxLength: 255, unicode: false),
                        Image = c.String(maxLength: 255, unicode: false),
                        Summary = c.String(maxLength: 500),
                        Content = c.String(maxLength: 4000),
                        CategoryID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        ContactName = c.String(nullable: false, maxLength: 255),
                        ContactEmail = c.String(nullable: false, maxLength: 50, unicode: false),
                        Content = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        PostID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostID, t.TagID })
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Slug = c.String(maxLength: 255, unicode: false),
                        Summary = c.String(maxLength: 500),
                        CategoryID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropIndex("dbo.SubCategories", new[] { "CategoryID" });
            DropIndex("dbo.PostTags", new[] { "TagID" });
            DropIndex("dbo.PostTags", new[] { "PostID" });
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropTable("dbo.SubCategories");
            DropTable("dbo.Tags");
            DropTable("dbo.PostTags");
            DropTable("dbo.Contacts");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
