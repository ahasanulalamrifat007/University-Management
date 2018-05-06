using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class CourseManager
    {
        CourseGetWay aCourseGetWay=new CourseGetWay();

        public int SaveCourse(Course aCourse)
        {
            return aCourseGetWay.SaveCourse(aCourse);
        }

        public List<Course> GetAllCourse()
        {
            return aCourseGetWay.GetAllCourse();
        }
    }

}