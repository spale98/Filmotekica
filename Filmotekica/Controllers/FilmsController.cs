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
    public class FilmsController : Controller
    {
        private readonly FilmotekicaDBEntities db = new FilmotekicaDBEntities();

        // GET: Films
        public ActionResult Index()
        {
            var films = db.films.Include(f => f.reziser).Include(f => f.zanr);
            return View(films.ToList());
        }

        // GET: Films/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            film film = db.films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Films/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.films, "id", "imefilma");
            ViewBag.id = new SelectList(db.films, "id", "imefilma");
            ViewBag.reziser_id = new SelectList(db.rezisers, "id", "imerezisera");
            ViewBag.zanr_id = new SelectList(db.zanrs, "id", "zanr1");
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,imefilma,opis,reziser_id,zanr_id")] film film)
        {
            if (ModelState.IsValid)
            {
                db.films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.films, "id", "imefilma", film.id);
            ViewBag.id = new SelectList(db.films, "id", "imefilma", film.id);
            ViewBag.reziser_id = new SelectList(db.rezisers, "id", "imerezisera", film.reziser_id);
            ViewBag.zanr_id = new SelectList(db.zanrs, "id", "zanr1", film.zanr_id);
            return View(film);
        }

        // GET: Films/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            film film = db.films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.films, "id", "imefilma", film.id);
            ViewBag.id = new SelectList(db.films, "id", "imefilma", film.id);
            ViewBag.reziser_id = new SelectList(db.rezisers, "id", "imerezisera", film.reziser_id);
            ViewBag.zanr_id = new SelectList(db.zanrs, "id", "zanr1", film.zanr_id);
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,imefilma,opis,reziser_id,zanr_id")] film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.films, "id", "imefilma", film.id);
            ViewBag.id = new SelectList(db.films, "id", "imefilma", film.id);
            ViewBag.reziser_id = new SelectList(db.rezisers, "id", "imerezisera", film.reziser_id);
            ViewBag.zanr_id = new SelectList(db.zanrs, "id", "zanr1", film.zanr_id);
            return View(film);
        }

        // GET: Films/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            film film = db.films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            film film = db.films.Find(id);
            db.films.Remove(film);
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
