namespace BlogEngine.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Audit_RemoveProperty_AuthorName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "AuthorName");
            DropColumn("dbo.Comments", "AuthorName");
            DropColumn("dbo.Posts", "AuthorName");
            DropColumn("dbo.Tags", "AuthorName");
            DropColumn("dbo.SubCategories", "AuthorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubCategories", "AuthorName", c => c.String(maxLength: 255));
            AddColumn("dbo.Tags", "AuthorName", c => c.String(maxLength: 255));
            AddColumn("dbo.Posts", "AuthorName", c => c.String(maxLength: 255));
            AddColumn("dbo.Comments", "AuthorName", c => c.String(maxLength: 255));
            AddColumn("dbo.Categories", "AuthorName", c => c.String(maxLength: 255));
        }
    }
}
