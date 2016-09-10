namespace QUp.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsHotfix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "IsHotfix", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "IsHotfix");
        }
    }
}
