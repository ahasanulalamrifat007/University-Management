using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVC.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide Code")]
        [MinLength(5, ErrorMessage = "Code must be least (5)characters long")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Provide Name")]
        public string Name { get; set; }
        [Range(.5,5 , ErrorMessage = "Credit value Must Be .5 to 5.0")]
        public double Credit { get; set; }
        [Required(ErrorMessage = "Please Provide Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select Semester")]
        public int SemesterId { get; set; }
    }
}