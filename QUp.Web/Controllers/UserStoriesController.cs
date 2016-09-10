using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QUp.DataModel;
using QUp.Domain;

namespace QUp.Web.Controllers
{
    public class UserStoriesController : Controller
    {
        private QUpContext db = new QUpContext();

        // GET: UserStories
        public ActionResult Index()
        {
            return View(db.Stories.ToList());
        }

        // GET: UserStories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStory userStory = db.Stories.Find(id);
            if (userStory == null)
            {
                return HttpNotFound();
            }
            return View(userStory);
        }

        // GET: UserStories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Keywords,Status,Feature")] UserStory userStory)
        {
            if (ModelState.IsValid)
            {
                db.Stories.Add(userStory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userStory);
        }

        // GET: UserStories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStory userStory = db.Stories.Find(id);
            if (userStory == null)
            {
                return HttpNotFound();
            }
            return View(userStory);
        }

        // POST: UserStories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Keywords,Status")] UserStory userStory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userStory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userStory);
        }

        // GET: UserStories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStory userStory = db.Stories.Find(id);
            if (userStory == null)
            {
                return HttpNotFound();
            }
            return View(userStory);
        }

        // POST: UserStories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserStory userStory = db.Stories.Find(id);
            db.Stories.Remove(userStory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
