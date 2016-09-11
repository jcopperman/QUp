using QUp.Domain;
using System;
using System.Data.Entity;

namespace QUp.DataModel
{
    public interface IQUpContext : IDisposable
    {
        DbSet<Project> Projects { get; set; }
        DbSet<Sprint> Sprints { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<UserStory> Stories { get; set; }
        DbSet<Issues> Issues { get; set; }

        int SaveChanges();
        void MarkAsModified(Project item);
    }
}
