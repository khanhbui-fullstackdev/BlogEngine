namespace BlogEngine.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Audit_AddNewProperty_AuthorName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "AuthorName", c => c.String(maxLength: 255));
            AddColumn("dbo.Comments", "AuthorName", c => c.String(maxLength: 255));
            AddColumn("dbo.Posts", "AuthorName", c => c.String(maxLength: 255));
            AddColumn("dbo.Tags", "AuthorName", c => c.String(maxLength: 255));
            AddColumn("dbo.SubCategories", "AuthorName", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubCategories", "AuthorName");
            DropColumn("dbo.Tags", "AuthorName");
            DropColumn("dbo.Posts", "AuthorName");
            DropColumn("dbo.Comments", "AuthorName");
            DropColumn("dbo.Categories", "AuthorName");
        }
    }
}
