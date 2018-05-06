using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVC.Models.ViewModels
{
    public class Enrollcd
    {
        public int  DepartmentId    { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string RegistrationNo { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
    }
}