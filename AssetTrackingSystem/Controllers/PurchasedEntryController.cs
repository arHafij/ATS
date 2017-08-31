using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem.ViewModels;
using ATS.DAL.Database;
using ATS.Models;
using AutoMapper;

namespace AssetTrackingSystem.Controllers
{
    public class PurchasedEntryController : Controller
    {
        AssetTrackingSystemContext db = new AssetTrackingSystemContext();
        // GET: PurchasedEntry
        public ActionResult Create()
        {
            PurchasedEntryCreateVM vm = new PurchasedEntryCreateVM();
            vm.ModelLookUpList = new SelectList(db.Models,"ModelId","Name");
            vm.GenCategoryLookUpList = new SelectList(db.GenCategories,"GenCategoryId","Name");
            vm.CategoryLookUpList = new SelectList(db.Categories, "CategoryId", "Name");
            vm.ManufacturerLookUpList = new SelectList(db.Manufacturers, "ManufacturerId", "Name");
            vm.SubCategoryLookUpList = new SelectList(db.SubCategories,"Id","Name");
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(PurchasedEntryCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                PurchasedAsset purchasedAsset = new PurchasedAsset()
                {
                    Price = vm.Price,
                    ModelId = vm.ModelId,
                    VendorName = vm.VendorName,
                    VendorAddress = vm.VendorAddress,
                    PurchasedDate = vm.PurchasedDate,
                    Quantity = vm.Quantity,
                    SerialNo = vm.SerialNo,
                    WarrantyPeriod = vm.WarrantyPeriod,

                };
                
                db.PurchasedAssets.Add(purchasedAsset);
                db.SaveChanges();
            }
            return RedirectToAction("Create","PurchasedEntry");
        }

        [HttpPost]
        public JsonResult GetCategoryByGenCategoryId(long genCategoryId)
        {
            AssetTrackingSystemContext db = new AssetTrackingSystemContext();
            var categories = db.Categories.Where(c=>c.GenCategoryId == genCategoryId).ToList();
            var categoryJsonData =
                categories.Select(c => new {c.CategoryId, c.GenCategoryId, c.Description, c.Name, c.ShortName});
            return Json(categoryJsonData, JsonRequestBehavior.AllowGet);

        }
    }
}