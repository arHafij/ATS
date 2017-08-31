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
    public class ModelsController : Controller
    {
        private AssetTrackingSystemContext db = new AssetTrackingSystemContext();

        // GET: Models
        public ActionResult Index()
        {
            var models = db.Models.Include(m => m.Manufacturer).Include(m => m.SubCategory);
            return View(models.ToList());
        }

        // GET: Models/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Models/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name");
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "Id", "Name");
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelId,Name,SubCategoryId,ManufacturerId")] Model model)
        {
            if (ModelState.IsValid)
            {
                db.Models.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", model.ManufacturerId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "Id", "Name", model.SubCategoryId);
            return View(model);
        }

        // GET: Models/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", model.ManufacturerId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "Id", "Name", model.SubCategoryId);
            return View(model);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelId,Name,SubCategoryId,ManufacturerId")] Model model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", model.ManufacturerId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "Id", "Name", model.SubCategoryId);
            return View(model);
        }

        // GET: Models/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Model model = db.Models.Find(id);
            db.Models.Remove(model);
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
