using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedemo.Models
{
    public class College
    {
        [Required]
        [Display(Name ="Id")]
        public Guid CollegeID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be Greater then 10 and less the 100", MinimumLength =10)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be Greater then 10 and less the 100", MinimumLength = 10)]
        [Display(Name = "Curriculam")]
        public string Curriculam { get; set; }
        [Required]
        [Display(Name = "Fees")]
        public double Fees { get; set; }
    }
}
