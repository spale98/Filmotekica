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
    public class ZanrsController : Controller
    {
        private FilmotekicaDBEntities db = new FilmotekicaDBEntities();

        // GET: Zanrs
        public ActionResult Index()
        {
            return View(db.zanrs.ToList());
        }

        // GET: Zanrs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zanr zanr = db.zanrs.Find(id);
            if (zanr == null)
            {
                return HttpNotFound();
            }
            return View(zanr);
        }

        // GET: Zanrs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zanrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,zanr1,opis")] zanr zanr)
        {
            if (ModelState.IsValid)
            {
                db.zanrs.Add(zanr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zanr);
        }

        // GET: Zanrs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zanr zanr = db.zanrs.Find(id);
            if (zanr == null)
            {
                return HttpNotFound();
            }
            return View(zanr);
        }

        // POST: Zanrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,zanr1,opis")] zanr zanr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zanr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zanr);
        }

        // GET: Zanrs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zanr zanr = db.zanrs.Find(id);
            if (zanr == null)
            {
                return HttpNotFound();
            }
            return View(zanr);
        }

        // POST: Zanrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            zanr zanr = db.zanrs.Find(id);
            db.zanrs.Remove(zanr);
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
