using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using trashcollector.Models;

namespace trashcollector.Controllers
{
    public class AnonymousUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AnonymousUsers
        public ActionResult Index()
        {
            return View(db.AnonymousUser.ToList());
        }

        // GET: AnonymousUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnonymousUser anonymousUser = db.AnonymousUser.Find(id);
            if (anonymousUser == null)
            {
                return HttpNotFound();
            }
            return View(anonymousUser);
        }

        // GET: AnonymousUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnonymousUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] AnonymousUser anonymousUser)
        {
            if (ModelState.IsValid)
            {
                db.AnonymousUser.Add(anonymousUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anonymousUser);
        }

        // GET: AnonymousUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnonymousUser anonymousUser = db.AnonymousUser.Find(id);
            if (anonymousUser == null)
            {
                return HttpNotFound();
            }
            return View(anonymousUser);
        }

        // POST: AnonymousUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] AnonymousUser anonymousUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anonymousUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anonymousUser);
        }

        // GET: AnonymousUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnonymousUser anonymousUser = db.AnonymousUser.Find(id);
            if (anonymousUser == null)
            {
                return HttpNotFound();
            }
            return View(anonymousUser);
        }

        // POST: AnonymousUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnonymousUser anonymousUser = db.AnonymousUser.Find(id);
            db.AnonymousUser.Remove(anonymousUser);
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
