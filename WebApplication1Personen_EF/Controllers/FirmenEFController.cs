using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1Personen_EF.Data;
using WebApplication1Personen_EF.Models;

namespace WebApplication1Personen_EF.Controllers
{
    public class FirmenEFController : Controller
    {
        private WebApplication1Personen_EFContext db = new WebApplication1Personen_EFContext();

        // GET: FirmenEF
        public ActionResult Index()
        {
            string urlStr = HttpContext.Request.Url.PathAndQuery;

            List<Firmen> firmenListe = db.Firmen.ToList();

            if (urlStr.IndexOf("orderByPlzAsc", 0, StringComparison.OrdinalIgnoreCase) >=0)
            {
                firmenListe = firmenListe.OrderBy(x => x.PLZ).ToList();
            }
            else if (urlStr.Contains("orderByPlzDesc"))
            {
                firmenListe = firmenListe.OrderByDescending(x => x.PLZ).ToList();
            }

            return View(firmenListe);
        }

        public ActionResult Details(int? id)
        {
            Firmen f = db.Firmen.Where(x => x.Id == id).FirstOrDefault();

            var pl = f.PersonenListe.ToList();

            return View(f);

        }

        // GET: FirmenEF/Details/5
        public ActionResult DetailsALT(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Firmen firmen = db.Firmen.Find(id);
            //if (firmen == null)
            //{
            //    return HttpNotFound();
            //}

            //var personen = db.Personens.Where(x => x.Firma.Id == id).ToList();
            //ViewBag.personenListe = personen;

            //return View(firmen);

            return RedirectToAction("Index");

        }

        // GET: FirmenEF/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FirmenEF/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PLZ")] Firmen firmen)
        {
            if (ModelState.IsValid)
            {
                db.Firmen.Add(firmen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(firmen);
        }

        // GET: FirmenEF/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firmen firmen = db.Firmen.Find(id);
            if (firmen == null)
            {
                return HttpNotFound();
            }
            return View(firmen);
        }

        // POST: FirmenEF/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PLZ")] Firmen firmen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firmen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(firmen);
        }

        // GET: FirmenEF/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firmen firmen = db.Firmen.Find(id);
            if (firmen == null)
            {
                return HttpNotFound();
            }
            return View(firmen);
        }

        // POST: FirmenEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Firmen firmen = db.Firmen.Find(id);
            db.Firmen.Remove(firmen);
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
