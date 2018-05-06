using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVC.Models
{
    public class CourseAssignToTeacher
    {
        public int TeacherId { get; set; }
        
        public string TeacherName { get; set; }
        public string DesignationId { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        public double CreditTobeTaken { get; set; }
        public double RemainingCredit { get; set; }
       
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
         
        public string CourseName { get; set; }
        public double CourseCredit { get; set; }
        public bool Status { get; set; }

    }
}