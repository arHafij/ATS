using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATS.Models
{
    public class Location
    {
        public long LocationId { get; set; }
        [Required]
        [DisplayName("Location")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Short Name")]
        public string ShortName { get; set; }
        public string Code { get; set; }
        [DisplayName("Branch Name")]
        public long BranchId { get; set; }

        public virtual Branch Branch { get; set; }
    }
}