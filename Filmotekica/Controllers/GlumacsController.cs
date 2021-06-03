using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Filmotekica.Models;

namespace Filmotekica.Controllers
{
    public class GlumacsController : Controller
    {
        private FilmotekicaDBEntities db = new FilmotekicaDBEntities();

        // GET: Glumacs
        public ActionResult Index()
        {
            return View(db.glumacs.ToList());
        }

        // GET: Glumacs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            glumac glumac = db.glumacs.Find(id);
            if (glumac == null)
            {
                return HttpNotFound();
            }
            return View(glumac);
        }

        // GET: Glumacs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Glumacs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,imeglumca,prezimeglumca,username,password")] glumac glumac)
        {
            if (ModelState.IsValid)
            {
                db.glumacs.Add(glumac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(glumac);
        }

        // GET: Glumacs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            glumac glumac = db.glumacs.Find(id);
            if (glumac == null)
            {
                return HttpNotFound();
            }
            return View(glumac);
        }

        // POST: Glumacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,imeglumca,prezimeglumca,username,password")] glumac glumac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glumac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glumac);
        }

        // GET: Glumacs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            glumac glumac = db.glumacs.Find(id);
            if (glumac == null)
            {
                return HttpNotFound();
            }
            return View(glumac);
        }

        // POST: Glumacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            glumac glumac = db.glumacs.Find(id);
            db.glumacs.Remove(glumac);
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
