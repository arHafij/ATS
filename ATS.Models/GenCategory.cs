using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    public class GenCategory
    {
        public long GenCategoryId { get; set; }
        [DisplayName("General Category")]
        public string Name { get; set; }
        [StringLength(2, MinimumLength = 2)]
        [DisplayName("Short Name")]
        public string ShortName { get; set; }
        public string Description { get; set; }

        //Navigation property
        public virtual ICollection<Category> Categories { get; set; }
    }
}
