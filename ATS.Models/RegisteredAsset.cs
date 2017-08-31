using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    public class RegisteredAsset
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Registered ID")]
        public string RegisteredId { get; set; }

        [Required]
        [Display(Name = "Location")]
        public long LocationId { get; set; }
        [Required]
        public long PurchasedAssetId { get; set; }

        public virtual PurchasedAsset PurchasedAsset { get; set; }
        public virtual Location Location { get; set; }
    }
}
