namespace QUp.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sprints", "SprintId", "dbo.Sprints");
            DropIndex("dbo.Sprints", new[] { "SprintId" });
            DropColumn("dbo.Features", "DateModified");
            DropColumn("dbo.Features", "DateCreated");
            DropColumn("dbo.Sprints", "SprintId");
            DropColumn("dbo.Sprints", "DateModified");
            DropColumn("dbo.Sprints", "DateCreated");
            DropColumn("dbo.Projects", "DateModified");
            DropColumn("dbo.Projects", "DateCreated");
            DropColumn("dbo.UserStories", "DateModified");
            DropColumn("dbo.UserStories", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserStories", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserStories", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sprints", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sprints", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sprints", "SprintId", c => c.Int(nullable: false));
            AddColumn("dbo.Features", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Features", "DateModified", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Sprints", "SprintId");
            AddForeignKey("dbo.Sprints", "SprintId", "dbo.Sprints", "Id");
        }
    }
}
