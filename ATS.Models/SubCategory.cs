using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    public class SubCategory
    {
        public long Id { get; set; }
        [Display(Name = "Sub Category")]
        public string Name { get; set; }
        public long CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
