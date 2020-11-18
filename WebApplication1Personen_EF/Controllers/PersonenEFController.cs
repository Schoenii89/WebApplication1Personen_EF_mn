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
    public class PersonenEFController : Controller
    {
        private WebApplication1Personen_EFContext db = new WebApplication1Personen_EFContext();

        public static List<Firmen> firmList = new List<Firmen>();


        [HttpGet]
        public ActionResult FirmaZuordnenNeu(int Id)
        {
            Personen p = db.Personens.Where(x => x.Id == Id).FirstOrDefault();

            firmList = db.Firmen.ToList();

            return View(p);
        }


        [HttpPost]
        public ActionResult FirmaZuordnenNeu(FormCollection fc)
        {
            int pid = Convert.ToInt32(fc[0]);
            Personen p = db.Personens.Where(x => x.Id == pid).FirstOrDefault();

            int fid = Convert.ToInt32(fc[1]);
            Firmen f = db.Firmen.Where(x => x.Id == fid).FirstOrDefault();

            p.FirmenListe.Add(f);

            db.SaveChanges();

            return RedirectToAction("Index");


        }


        public ActionResult FirmaZuordenALT(int Id)
        {
            //firmList = db.Firmen.ToList();

            //var p = db.Personens.Where(x => x.Id == Id).FirstOrDefault();

            //return View(p);

            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult FirmaZuordenALT(FormCollection formCollection)
        {
            //int personenId = Int32.Parse(formCollection[0]);
            //int firmenId = Int32.Parse(formCollection[1]);

            //var p = db.Personens.Where(x => x.Id == personenId).FirstOrDefault();

            //var f = db.Firmen.Where(x => x.Id == firmenId).FirstOrDefault();

            //p.Firma = f;

            //db.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: PersonenEF

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.PersonenSort = sortOrder == "1" ? "" : "1";
            ViewBag.PersonenSort1 = sortOrder == "2" ? "3" : "2";

            IQueryable<Personen> allPersonen = from x in db.Personens select x;

            if (!string.IsNullOrEmpty(searchString))
            {
                allPersonen = allPersonen.Where(x => x.Nachname.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "1":
                    allPersonen = allPersonen.OrderBy(x => x.Vorname);
                    break;
                case "2":
                    allPersonen = allPersonen.OrderByDescending(x => x.Nachname);
                    break;
                case "3":
                    allPersonen = allPersonen.OrderBy(x => x.Nachname);
                    break;
                default:
                    allPersonen = allPersonen.OrderByDescending(x => x.Vorname);
                    break;
            }
            return View(allPersonen.ToList());
        }


        public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Personen personen = db.Personens.Find(id);
        if (personen == null)
        {
            return HttpNotFound();
        }
        return View(personen);
    }

    // GET: PersonenEF/Details/5
    public ActionResult DetailsALT(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Personen personen = db.Personens.Find(id);
        if (personen == null)
        {
            return HttpNotFound();
        }
        return View(personen);
    }

    // GET: PersonenEF/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PersonenEF/Create
    // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
    // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Vorname,Nachname,Geburtstag,EmailAdr,TelNummer,Geburtsjahr")] Personen personen)
    {
        if (ModelState.IsValid)
        {
            db.Personens.Add(personen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(personen);
    }

    // GET: PersonenEF/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Personen personen = db.Personens.Find(id);
        if (personen == null)
        {
            return HttpNotFound();
        }
        return View(personen);
    }

    // POST: PersonenEF/Edit/5
    // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
    // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Vorname,Nachname,Geburtstag,EmailAdr,TelNummer")] Personen personen)
    {
        if (ModelState.IsValid)
        {
            db.Entry(personen).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(personen);
    }

    // GET: PersonenEF/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Personen personen = db.Personens.Find(id);
        if (personen == null)
        {
            return HttpNotFound();
        }
        return View(personen);
    }

    // POST: PersonenEF/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Personen personen = db.Personens.Find(id);
        db.Personens.Remove(personen);
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
