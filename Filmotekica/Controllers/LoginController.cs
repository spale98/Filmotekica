using Filmotekica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filmotekica.Controllers
{
    public class LoginController : Controller
    {
        FilmotekicaDBEntities db = new FilmotekicaDBEntities();


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(glumac objck)
        {

            if(ModelState.IsValid)
            {
                using (FilmotekicaDBEntities db = new FilmotekicaDBEntities())
                {
                    var obj = db.glumacs.Where(a => a.username.Equals(objck.username) && a.password.Equals(objck.password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["GlumacID"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ModelState.AddModelError("", "Korisnicko ime ili lozinka nisu ispravni");
                    }
                }
            }
            return View(objck);
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}