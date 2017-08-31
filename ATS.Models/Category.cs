using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        [DisplayName("Category")]
     
        public string Name { get; set; }
        [DisplayName("Short Name")]
       
        public string ShortName { get; set; }
        public string Description { get; set; }
        public long GenCategoryId { get; set; }

        //NavigationProperty
        public virtual GenCategory GenCategory { get; set; }
        public  virtual ICollection<Model> Models { get; set; }
    }
}
