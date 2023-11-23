using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using schlapp;

namespace schlapp.Controllers
{
    public class classesController : Controller
    {
        private schooldbsEntities db = new schooldbsEntities();

        // GET: classes
        public ActionResult Index()
        {
            return View(db.classes.ToList());
        }

        // GET: classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classe classe = db.classes.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // GET: classes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] classe classe)
        {
            if (ModelState.IsValid)
            {
                db.classes.Add(classe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classe);
        }

        // GET: classes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classe classe = db.classes.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // POST: classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] classe classe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classe);
        }

        // GET: classes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classe classe = db.classes.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // POST: classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            classe classe = db.classes.Find(id);
            db.classes.Remove(classe);
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
