using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ATS.DAL.Database;
using ATS.Models;

namespace AssetTrackingSystem.Controllers
{
    public class GenCategoriesController : Controller
    {
        private AssetTrackingSystemContext db = new AssetTrackingSystemContext();

        // GET: GenCategories
        public ActionResult Index()
        {
            return View(db.GenCategories.ToList());
        }

        // GET: GenCategories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenCategory genCategory = db.GenCategories.Find(id);
            if (genCategory == null)
            {
                return HttpNotFound();
            }
            return View(genCategory);
        }

        // GET: GenCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenCategoryId,Name,ShortName,Description")] GenCategory genCategory)
        {
            if (ModelState.IsValid)
            {
                db.GenCategories.Add(genCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genCategory);
        }

        // GET: GenCategories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenCategory genCategory = db.GenCategories.Find(id);
            if (genCategory == null)
            {
                return HttpNotFound();
            }
            return View(genCategory);
        }

        // POST: GenCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenCategoryId,Name,ShortName,Description")] GenCategory genCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genCategory);
        }

        // GET: GenCategories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenCategory genCategory = db.GenCategories.Find(id);
            if (genCategory == null)
            {
                return HttpNotFound();
            }
            return View(genCategory);
        }

        // POST: GenCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            GenCategory genCategory = db.GenCategories.Find(id);
            db.GenCategories.Remove(genCategory);
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
