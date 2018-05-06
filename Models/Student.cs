using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string RegistrarionNo { get; set; }
        [Required(ErrorMessage = "Please Provide Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Provide Contact Number")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please Select Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Please Provide Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        public string Code { get; set; }
    }
}