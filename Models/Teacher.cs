using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVC.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Provide Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Provide Contact Number")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please Select Designation")]
        public int DesignationId { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please Provide Positive Value")]
        [Required(ErrorMessage = "Please Provide Credit")]
        public double CreditTobeTaken { get; set; }
        public double RemainingCredit { get; set; }
        public int CourseId { get; set; }
        public  bool Status { get; set; }
    }
}