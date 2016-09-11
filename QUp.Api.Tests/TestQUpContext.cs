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
        }

        public DbSet<Project> Projects { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Project item) { }
        public void Dispose() { }
    }
}
