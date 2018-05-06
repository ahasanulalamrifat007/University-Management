using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVC.Models
{
    public class StudentResult
    {
        [Required(ErrorMessage = "Please Select Registration Number")]
        public string RegistrationNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Please Select Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please Enter Mid Number")]
        public int MidNum { get; set; }
        [Required(ErrorMessage = "Please Enter Quize Number")]
        public int QuizeNum { get; set; }
        [Required(ErrorMessage = "Please Enter Assignment Number")]
        public int AsignmentNum { get; set; }
        [Required(ErrorMessage = "Please Enter Attendence Number")]
        public int Attendence { get; set; }
        [Required(ErrorMessage = "Please Enter Final Number")]
        public int FinalNum { get; set; }
        [Required(ErrorMessage = "Please Select Grade")]
        public string Grade { get; set; }
    }
}