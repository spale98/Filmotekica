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
    public class RezisersController : Controller
    {
        private FilmotekicaDBEntities db = new FilmotekicaDBEntities();

        // GET: Rezisers
        public ActionResult Index()
        {
            return View(db.rezisers.ToList());
        }

        // GET: Rezisers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reziser reziser = db.rezisers.Find(id);
            if (reziser == null)
            {
                return HttpNotFound();
            }
            return View(reziser);
        }

        // GET: Rezisers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rezisers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,imerezisera,starost")] reziser reziser)
        {
            if (ModelState.IsValid)
            {
                db.rezisers.Add(reziser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reziser);
        }

        // GET: Rezisers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reziser reziser = db.rezisers.Find(id);
            if (reziser == null)
            {
                return HttpNotFound();
            }
            return View(reziser);
        }

        // POST: Rezisers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,imerezisera,starost")] reziser reziser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reziser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reziser);
        }

        // GET: Rezisers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reziser reziser = db.rezisers.Find(id);
            if (reziser == null)
            {
                return HttpNotFound();
            }
            return View(reziser);
        }

        // POST: Rezisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reziser reziser = db.rezisers.Find(id);
            db.rezisers.Remove(reziser);
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
