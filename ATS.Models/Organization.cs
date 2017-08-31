using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    public class Organization
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Organization Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Short Name")]
        public string ShortName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
    }
}
