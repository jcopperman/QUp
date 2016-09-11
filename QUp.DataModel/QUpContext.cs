using QUp.Domain;
using QUp.Domain.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace QUp.DataModel
{
    public class QUpContext : DbContext, IQUpContext
    {
        public QUpContext() : base("name=QUpContext")
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<UserStory> Stories { get; set; }
        public DbSet<Issues> Issues { get; set; }

        public void MarkAsModified(Project item)
        {
            Entry(item).State = EntityState.Modified;
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Types().
        //        Configure(c => c.Ignore("IsDirty"));
        //    base.OnModelCreating(modelBuilder);
        //}

        //public override int SaveChanges()
        //{
        //    foreach (var history in this.ChangeTracker.Entries()
        //      .Where(e => e.Entity is IModificationHistory && (e.State == EntityState.Added ||
        //              e.State == EntityState.Modified))
        //       .Select(e => e.Entity as IModificationHistory)
        //      )
        //    {
        //        history.DateModified = DateTime.Now;
        //        if (history.DateCreated == DateTime.MinValue)
        //        {
        //            history.DateCreated = DateTime.Now;
        //        }
        //    }
        //    int result = base.SaveChanges();
        //    foreach (var history in this.ChangeTracker.Entries()
        //                                  .Where(e => e.Entity is IModificationHistory)
        //                                  .Select(e => e.Entity as IModificationHistory)
        //      )
        //    {
        //        history.IsDirty = false;
        //    }
        //    return result;
        //}
    }
}
