using QUp.Domain;
using System;
using System.Data.Entity;

namespace QUp.DataModel
{
    public interface IQUpContext : IDisposable
    {
        DbSet<Project> Projects { get; set; }
        int SaveChanges();
        void MarkAsModified(Project item);
    }
}
