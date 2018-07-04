namespace BlogEngine.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Post_AddProperty_Quote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Quote", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Quote");
        }
    }
}
