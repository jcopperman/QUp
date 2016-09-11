using QUp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUp.DataModel.DAL
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects();
        Project GetProjectByID(int projectId);
        void InsertProject(Project project);
        void DeleteProject(int projectId);
        bool UpdateProject(Project project);
        bool Save();
    }
}
