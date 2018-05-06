using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVC.Models
{
    public class Enroll
    {
        [Required(ErrorMessage = "Please Select Regestration Number")]
        public string StudentRegNo { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentDepartmentId { get; set; }
        public string StudentDepartmentName { get; set; }
        [Required(ErrorMessage = "Please Select Course")]
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}