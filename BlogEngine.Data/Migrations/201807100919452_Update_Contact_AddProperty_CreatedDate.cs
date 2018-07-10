namespace BlogEngine.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Contact_AddProperty_CreatedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "CreatedDate");
        }
    }
}
