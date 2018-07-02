namespace BlogEngine.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Audit_AddProperty_Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tags", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.SubCategories", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubCategories", "Status");
            DropColumn("dbo.Tags", "Status");
            DropColumn("dbo.Posts", "Status");
            DropColumn("dbo.Comments", "Status");
            DropColumn("dbo.Categories", "Status");
        }
    }
}
