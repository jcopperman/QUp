using QUp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUp.DataModel.DAL
{
    public class ProjectRepository
    {
        private QUpContext context;

        public ProjectRepository(QUpContext context)
        {
            this.context = context;
        }

        public IEnumerable<Project> GetStudents()
        {
            return context.Projects.ToList();
        }

        public Project GetStudentByID(int id)
        {
            return context.Projects.Find(id);
        }

        public void InsertStudent(Project student)
        {
            context.Projects.Add(student);
        }

        public void DeleteStudent(int studentID)
        {
            Project project = context.Projects.Find(studentID);
            context.Projects.Remove(project);
        }

        public void UpdateStudent(Project project)
        {
            context.Entry(project).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
