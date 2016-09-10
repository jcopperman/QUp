namespace QUp.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Keywords = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Sprint_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sprints", t => t.Sprint_Id)
                .Index(t => t.Sprint_Id);
            
            CreateTable(
                "dbo.Sprints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SprintId = c.Int(nullable: false),
                        SprintStartDate = c.DateTime(nullable: false),
                        SprintEndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .ForeignKey("dbo.Sprints", t => t.SprintId)
                .Index(t => t.SprintId)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Keywords = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Feature_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.Feature_Id)
                .Index(t => t.Feature_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserStories", "Feature_Id", "dbo.Features");
            DropForeignKey("dbo.Features", "Sprint_Id", "dbo.Sprints");
            DropForeignKey("dbo.Sprints", "SprintId", "dbo.Sprints");
            DropForeignKey("dbo.Sprints", "Project_Id", "dbo.Projects");
            DropIndex("dbo.UserStories", new[] { "Feature_Id" });
            DropIndex("dbo.Sprints", new[] { "Project_Id" });
            DropIndex("dbo.Sprints", new[] { "SprintId" });
            DropIndex("dbo.Features", new[] { "Sprint_Id" });
            DropTable("dbo.UserStories");
            DropTable("dbo.Projects");
            DropTable("dbo.Sprints");
            DropTable("dbo.Features");
        }
    }
}
