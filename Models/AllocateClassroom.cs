using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Web;

namespace UniversityManagementSystemMVC.Models
{
    public class AllocateClassroom
    {

       [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        [Required(ErrorMessage = "Please Select Course")]
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Please Select Room")]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Please Select Day")]
        public int DayId { get; set; }
        [Required(ErrorMessage = "Please Select Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
        public DateTime From { get; set; }
        [Required(ErrorMessage = "Please Select Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
        
        public DateTime To { get; set; }
        public string Status { get; set; }
    }
}