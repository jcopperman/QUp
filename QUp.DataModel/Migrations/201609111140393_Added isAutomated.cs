namespace QUp.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedisAutomated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserStories", "IsAutomated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserStories", "IsAutomated");
        }
    }
}
