using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Police.Models;

namespace Police.Controllers
{
    public class CriminalsController : Controller
    {
        private CriminalDBContext db = new CriminalDBContext();

        // GET: Criminals
        public ActionResult Index(string searchString)
        {
            var criminals = from m in db.Criminals select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                criminals = criminals.Where(s => s.CriminalName.Contains(searchString));
            }

            return View(criminals);
        }

        // GET: Criminals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criminal criminal = db.Criminals.Find(id);
            if (criminal == null)
            {
                return HttpNotFound();
            }
            return View(criminal);
        }

        // GET: Criminals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Criminals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CriminalName,DateOfArrest,Crimes,Sanction,ArrestingOfficer")] Criminal criminal)
        {
            if (ModelState.IsValid)
            {
                db.Criminals.Add(criminal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(criminal);
        }

        // GET: Criminals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criminal criminal = db.Criminals.Find(id);
            if (criminal == null)
            {
                return HttpNotFound();
            }
            return View(criminal);
        }

        // POST: Criminals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CriminalName,DateOfArrest,Crimes,Sanction,ArrestingOfficer")] Criminal criminal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criminal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(criminal);
        }

        // GET: Criminals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criminal criminal = db.Criminals.Find(id);
            if (criminal == null)
            {
                return HttpNotFound();
            }
            return View(criminal);
        }

        // POST: Criminals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Criminal criminal = db.Criminals.Find(id);
            db.Criminals.Remove(criminal);
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
