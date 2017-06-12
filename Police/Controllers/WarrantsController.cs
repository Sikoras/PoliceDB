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
    public class WarrantsController : Controller
    {
        private WarrantDBContext db = new WarrantDBContext();

        // GET: Warrants
        public ActionResult Index()
        {
            return View(db.Warrants.ToList());
        }

        // GET: Warrants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warrant warrant = db.Warrants.Find(id);
            if (warrant == null)
            {
                return HttpNotFound();
            }
            return View(warrant);
        }

        // GET: Warrants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warrants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CriminalName,Crimes,FilingOfficer,Notes")] Warrant warrant)
        {
            if (ModelState.IsValid)
            {
                db.Warrants.Add(warrant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warrant);
        }

        // GET: Warrants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warrant warrant = db.Warrants.Find(id);
            if (warrant == null)
            {
                return HttpNotFound();
            }
            return View(warrant);
        }

        // POST: Warrants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CriminalName,Crimes,FilingOfficer,Notes")] Warrant warrant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warrant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warrant);
        }

        // GET: Warrants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warrant warrant = db.Warrants.Find(id);
            if (warrant == null)
            {
                return HttpNotFound();
            }
            return View(warrant);
        }

        // POST: Warrants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Warrant warrant = db.Warrants.Find(id);
            db.Warrants.Remove(warrant);
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
