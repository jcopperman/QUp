using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using QUp.DataModel;
using QUp.Domain;

namespace QUp.Api.Controllers
{
    public class SprintsController : ApiController
    {
        private QUpContext db = new QUpContext();

        // GET: api/Sprints
        public IQueryable<Sprint> GetSprints()
        {
            return db.Sprints;
        }

        // GET: api/Sprints/5
        [ResponseType(typeof(Sprint))]
        public IHttpActionResult GetSprint(int id)
        {
            Sprint sprint = db.Sprints.Find(id);
            if (sprint == null)
            {
                return NotFound();
            }

            return Ok(sprint);
        }

        // PUT: api/Sprints/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSprint(int id, Sprint sprint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sprint.Id)
            {
                return BadRequest();
            }

            db.Entry(sprint).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SprintExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Sprints
        [ResponseType(typeof(Sprint))]
        public IHttpActionResult PostSprint(Sprint sprint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sprints.Add(sprint);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sprint.Id }, sprint);
        }

        // DELETE: api/Sprints/5
        [ResponseType(typeof(Sprint))]
        public IHttpActionResult DeleteSprint(int id)
        {
            Sprint sprint = db.Sprints.Find(id);
            if (sprint == null)
            {
                return NotFound();
            }

            db.Sprints.Remove(sprint);
            db.SaveChanges();

            return Ok(sprint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SprintExists(int id)
        {
            return db.Sprints.Count(e => e.Id == id) > 0;
        }
    }
}