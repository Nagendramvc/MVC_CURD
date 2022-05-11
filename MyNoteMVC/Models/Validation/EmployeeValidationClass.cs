using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyNoteMVC.Models.Validation
{
    public class EmployeeValidationClass
    {
        public int EID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string EName { get; set; }

        [Required]
        [Display(Name ="Email")]
        public string EEmail { get; set; }

        [Required]
        [Display(Name = "Mobile")]
        public string EMobile { get; set; }

        //public Nullable<bool> Status { get; set; }
        //public Nullable<System.DateTime> Createdate { get; set; }
        //public Nullable<System.DateTime> Updatedate { get; set; }
    }
}