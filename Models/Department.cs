using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc.Routing.Constraints;

namespace UniversityManagementSystemMVC.Models
{
    public class Department
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Please Provide Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Credit value Must Be 2 to 7")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Provide Name")]
        public string Name { get; set; }
    }
}