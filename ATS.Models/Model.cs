using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    public class Model
    {
        public long ModelId { get; set; }
        
        [DisplayName("Model Name")]
        public string Name { get; set; }
        public long SubCategoryId { get; set; }
        public long ManufacturerId { get; set; }

        //Navigation property
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}
