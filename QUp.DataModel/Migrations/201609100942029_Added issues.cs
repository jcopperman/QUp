namespace QUp.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedissues : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Feature_Id = c.Int(),
                        Story_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.Feature_Id)
                .ForeignKey("dbo.UserStories", t => t.Story_Id)
                .Index(t => t.Feature_Id)
                .Index(t => t.Story_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "Story_Id", "dbo.UserStories");
            DropForeignKey("dbo.Issues", "Feature_Id", "dbo.Features");
            DropIndex("dbo.Issues", new[] { "Story_Id" });
            DropIndex("dbo.Issues", new[] { "Feature_Id" });
            DropTable("dbo.Issues");
        }
    }
}
