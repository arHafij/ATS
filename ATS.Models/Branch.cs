using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATS.Models
{
    public class Branch
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Branch Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Short Name")]
        public string ShortName { get; set; }
        public string Code { get; set; }
        //Foreign key
        public long OrganizationId { get; set; }

        //Navigation property
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}