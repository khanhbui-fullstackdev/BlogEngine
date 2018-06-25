namespace BlogEngine.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_AbstractClass_Audit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CreatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Categories", "UpdatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Comments", "CreatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Comments", "UpdatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Posts", "Content", c => c.String());
            AlterColumn("dbo.Posts", "CreatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Posts", "UpdatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Tags", "CreatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Tags", "UpdatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.SubCategories", "CreatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.SubCategories", "UpdatedBy", c => c.String(maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubCategories", "UpdatedBy", c => c.String());
            AlterColumn("dbo.SubCategories", "CreatedBy", c => c.String());
            AlterColumn("dbo.Tags", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Tags", "CreatedBy", c => c.String());
            AlterColumn("dbo.Posts", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Posts", "CreatedBy", c => c.String());
            AlterColumn("dbo.Posts", "Content", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Comments", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Comments", "CreatedBy", c => c.String());
            AlterColumn("dbo.Categories", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Categories", "CreatedBy", c => c.String());
        }
    }
}
