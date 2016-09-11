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
    public class FeaturesController : ApiController
    {


        // GET: api/Features
        public IQueryable<Feature> GetFeatures()
        {
            using (var db = new QUpContext())
            {
                return db.Features;
            }
        }

        // GET: api/Features/5
        [ResponseType(typeof(Feature))]
        public IHttpActionResult GetFeature(int id)
        {
            Feature feature;
            using (var db = new QUpContext())
            {
                feature = db.Features.Find(id);
            }
            if (feature == null)
            {
                return NotFound();
            }


            return Ok(feature);
        }

        // PUT: api/Features/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeature(int id, Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feature.Id)
            {
                return BadRequest();
            }
            using (var db = new QUpContext())
            {
                db.Entry(feature).State = EntityState.Modified;


                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeatureExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Features
        [ResponseType(typeof(Feature))]
        public IHttpActionResult PostFeature(Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var db = new QUpContext())
            {
                db.Features.Add(feature);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = feature.Id }, feature);
        }

        // DELETE: api/Features/5
        [ResponseType(typeof(Feature))]
        public IHttpActionResult DeleteFeature(int id)
        {
            Feature feature;
            using (var db = new QUpContext())
            {
                feature = db.Features.Find(id);

                if (feature == null)
                {
                    return NotFound();
                }

                db.Features.Remove(feature);
                db.SaveChanges();
            }

            return Ok(feature);
        }

        protected override void Dispose(bool disposing)
        {
            using (var db = new QUpContext())
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private bool FeatureExists(int id)
        {
            using (var db = new QUpContext())
            {
                return db.Features.Count(e => e.Id == id) > 0;
            }
        }
    }
}