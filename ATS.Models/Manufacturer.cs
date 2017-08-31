using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    public class Manufacturer
    {
        public long ManufacturerId { get; set; }
        [DisplayName("Manufacturer Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation property
        public virtual ICollection<Model> Models { get; set; }
    }
}
