using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.BLL
{
    public class CourseStaticManager
    {
        CourseStaticGetWay aGetWay=new CourseStaticGetWay();

        public List<CourseStatics> GetAllCourseStaticses()
        {
            return aGetWay.GetAllCourseStaticses();
        }

        public List<CourseStatics> GetAllCourseStaticsesbyDepartmentId(int a)
        {
            return aGetWay.GetAllCourseStaticsesbyDepartmentId(a);
        }
    }
}