using QUp.DataModel;
using System;
using System.Data.Entity;
using QUp.Domain;

namespace QUp.Api.Tests
{
    public class TestQUpContext : IQUpContext
    {
        public TestQUpContext()
        {
            this.Projects = new TestProjectDbSet();
            //Todo add rest of the entities to context
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<UserStory> Stories { get; set; }
        public DbSet<Issues> Issues { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Project item) { }
        public void Dispose() { }
    }
}
