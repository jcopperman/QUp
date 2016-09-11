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
    public class UserStoriesController : ApiController
    {
        private IQUpContext db = new QUpContext();

        public UserStoriesController() { }

        public UserStoriesController(IQUpContext context)
        {
            db = context;
        }

        // GET: api/UserStories
        public IQueryable<UserStory> GetStories()
        {
            return db.Stories;
        }

        // GET: api/UserStories/5
        [ResponseType(typeof(UserStory))]
        public IHttpActionResult GetUserStory(int id)
        {
            UserStory userStory = db.Stories.Find(id);
            if (userStory == null)
            {
                return NotFound();
            }

            return Ok(userStory);
        }

        // PUT: api/UserStories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserStory(int id, UserStory userStory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userStory.Id)
            {
                return BadRequest();
            }

            db.Entry(userStory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStoryExists(id))
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

        // POST: api/UserStories
        [ResponseType(typeof(UserStory))]
        public IHttpActionResult PostUserStory(UserStory userStory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stories.Add(userStory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userStory.Id }, userStory);
        }

        // DELETE: api/UserStories/5
        [ResponseType(typeof(UserStory))]
        public IHttpActionResult DeleteUserStory(int id)
        {
            UserStory userStory = db.Stories.Find(id);
            if (userStory == null)
            {
                return NotFound();
            }

            db.Stories.Remove(userStory);
            db.SaveChanges();

            return Ok(userStory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserStoryExists(int id)
        {
            return db.Stories.Count(e => e.Id == id) > 0;
        }
    }
}