using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATS.Models;

namespace AssetTrackingSystem.ViewModels
{
    public class PurchasedEntryCreateVM
    {

        public long Id { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string VendorName { get; set; }
        [Required]
        public string VendorAddress { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PurchasedDate { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int SerialNo { get; set; }
        public int WarrantyPeriod { get; set; }
        //foreign key
        [Required]
        public long ModelId { get; set; }

        public SelectList CategoryLookUpList { get; set; }
        public SelectList GenCategoryLookUpList { get; set; }
        public SelectList ModelLookUpList { get; set; }
        public SelectList ManufacturerLookUpList { get; set; }
        public SelectList SubCategoryLookUpList { get; set; }
        public Manufacturer Manufacturer{ get; set; }
        public GenCategory GenCategory { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }


    }
}