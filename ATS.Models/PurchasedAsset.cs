using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    public class PurchasedAsset
    {
        public long Id { get; set; }
        public decimal Price { get; set; }  
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public DateTime PurchasedDate { get; set; }
        public int Quantity { get; set; }
        public int SerialNo { get; set; }
        public int WarrantyPeriod { get; set; }
        //foreign key
        public long ModelId { get; set; }

        public ICollection<RegisteredAsset> RegisteredAssets { get; set; }
        public Model Model { get; set; }

    }
}
