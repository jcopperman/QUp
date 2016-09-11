using QUp.Domain;
using QUp.Domain.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace QUp.DataModel
{
    public class QUpContext : DbContext, IQUpContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<UserStory> Stories { get; set; }
        public DbSet<Issues> Issues { get; set; }

        public void MarkAsModified(Project item)
        {
            throw new NotImplementedException();
        }
    }
}
