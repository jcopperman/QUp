using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QUp.DataModel;
using QUp.Domain;
using QUp.DataModel.DAL;

namespace QUp.Api.Controllers
{
    public class ProjectsController : ApiController
    {
        ProjectRepository projectRepo = new ProjectRepository(new QUpContext());

        // GET: api/Projects
        public IEnumerable<Project> GetProjects()
        {
            return projectRepo.GetProjects();
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(int id)
        {
            Project project = projectRepo.GetProjectByID(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.Id)
            {
                return BadRequest();
            }

            projectRepo.UpdateProject(project);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            projectRepo.InsertProject(project);

            return CreatedAtRoute("DefaultApi", new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(int id)
        {
            Project project = projectRepo.GetProjectByID(id);
            if (project == null)
            {
                return NotFound();
            }

            projectRepo.DeleteProject(id);

            return Ok(project);
        }        

        private bool ProjectExists(int id)
        {
            return projectRepo.ProjectExists(id);
        }
    }
}