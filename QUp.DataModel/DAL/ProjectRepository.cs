using QUp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUp.DataModel.DAL
{
    public class ProjectRepository : IProjectRepository
    {
        IQUpContext context;

        public ProjectRepository(IQUpContext _context)
        {
            context = _context;
        }

        public IEnumerable<Project> GetProjects()
        {
            return context.Projects.ToList();
        }

        public Project GetProjectByID(int projectId)
        {
            return context.Projects.Find(projectId);
        }

        public void InsertProject(Project project)
        {
            context.Projects.Add(project);

            Save();
        }

        public bool Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }


        public bool ProjectExists(int id)
        {
            return context.Projects.Count(e => e.Id == id) > 0;
        }

        public bool UpdateProject(Project _project)
        {
            Project project = GetProjectByID(_project.Id);
            project = _project;

            var result = Save();

            return result;
        }

        public void DeleteProject(int projectId)
        {
            Project project = context.Projects.Find(projectId);
            context.Projects.Remove(project);
        }
    }
}
