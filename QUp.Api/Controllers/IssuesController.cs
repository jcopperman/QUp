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

namespace QUp.Api.Controllers
{
    public class IssuesController : ApiController
    {
        private IQUpContext db = new QUpContext();

        public IssuesController() { }

        public IssuesController(IQUpContext context)
        {
            db = context;
        }

        // GET: api/Issues
        public IQueryable<Issues> GetIssues()
        {
            return db.Issues;
        }

        // GET: api/Issues/5
        [ResponseType(typeof(Issues))]
        public IHttpActionResult GetIssues(int id)
        {
            Issues issues = db.Issues.Find(id);
            if (issues == null)
            {
                return NotFound();
            }

            return Ok(issues);
        }

        // PUT: api/Issues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIssues(int id, Issues issues)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != issues.Id)
            {
                return BadRequest();
            }

            db.Entry(issues).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssuesExists(id))
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

        // POST: api/Issues
        [ResponseType(typeof(Issues))]
        public IHttpActionResult PostIssues(Issues issues)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Issues.Add(issues);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = issues.Id }, issues);
        }

        // DELETE: api/Issues/5
        [ResponseType(typeof(Issues))]
        public IHttpActionResult DeleteIssues(int id)
        {
            Issues issues = db.Issues.Find(id);
            if (issues == null)
            {
                return NotFound();
            }

            db.Issues.Remove(issues);
            db.SaveChanges();

            return Ok(issues);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IssuesExists(int id)
        {
            return db.Issues.Count(e => e.Id == id) > 0;
        }
    }
}