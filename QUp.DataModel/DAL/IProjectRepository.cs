using QUp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUp.DataModel.DAL
{
    public interface IProjectRepository : IDisposable
    {
        IEnumerable<Project> GetProjects();
        Project GetProjectsByID(int projectId);
        void InsertProject(Project project);
        void DeleteProject(int projectId);
        void UpdateProject(Project project);
        void Save();
    }
}
