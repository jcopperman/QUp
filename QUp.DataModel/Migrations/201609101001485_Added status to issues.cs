namespace QUp.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedstatustoissues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "Status");
        }
    }
}
