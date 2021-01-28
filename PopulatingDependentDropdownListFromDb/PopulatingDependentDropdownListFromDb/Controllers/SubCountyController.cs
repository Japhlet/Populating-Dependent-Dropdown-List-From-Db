using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PopulatingDependentDropdownListFromDb.Models;

namespace PopulatingDependentDropdownListFromDb.Controllers
{
    public class SubCountyController : Controller
    {
        private Db db = new Db();

        // GET: SubCounty
        public ActionResult Index()
        {
            var subCounty = db.subCounty.Include(s => s.county);
            return View(subCounty.ToList());
        }

        // GET: SubCounty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subCounty subCounty = db.subCounty.Find(id);
            if (subCounty == null)
            {
                return HttpNotFound();
            }
            return View(subCounty);
        }

        // GET: SubCounty/Create
        public ActionResult Create()
        {
            ViewBag.countyId = new SelectList(db.county, "id", "countyCode");
            return View();
        }

        // POST: SubCounty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,subCountyCode,subCountyName,countyId")] subCounty subCounty)
        {
            if (ModelState.IsValid)
            {
                db.subCounty.Add(subCounty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.countyId = new SelectList(db.county, "id", "countyCode", subCounty.countyId);
            return View(subCounty);
        }

        // GET: SubCounty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subCounty subCounty = db.subCounty.Find(id);
            if (subCounty == null)
            {
                return HttpNotFound();
            }
            ViewBag.countyId = new SelectList(db.county, "id", "countyCode", subCounty.countyId);
            return View(subCounty);
        }

        // POST: SubCounty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,subCountyCode,subCountyName,countyId")] subCounty subCounty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCounty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.countyId = new SelectList(db.county, "id", "countyCode", subCounty.countyId);
            return View(subCounty);
        }

        // GET: SubCounty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subCounty subCounty = db.subCounty.Find(id);
            if (subCounty == null)
            {
                return HttpNotFound();
            }
            return View(subCounty);
        }

        // POST: SubCounty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subCounty subCounty = db.subCounty.Find(id);
            db.subCounty.Remove(subCounty);
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
