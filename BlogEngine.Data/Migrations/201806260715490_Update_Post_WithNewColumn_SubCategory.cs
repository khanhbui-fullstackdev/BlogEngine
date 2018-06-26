namespace BlogEngine.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Post_WithNewColumn_SubCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "SubCategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "SubCategoryID");
            AddForeignKey("dbo.Posts", "SubCategoryID", "dbo.SubCategories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "SubCategoryID", "dbo.SubCategories");
            DropIndex("dbo.Posts", new[] { "SubCategoryID" });
            DropColumn("dbo.Posts", "SubCategoryID");
        }
    }
}
