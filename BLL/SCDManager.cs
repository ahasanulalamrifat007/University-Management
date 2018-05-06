using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.BLL
{
    public class SCDManager
    {
        SCDGetWay aGetWay=new SCDGetWay();

        public List<SCD> GetStudentInfoWithDepartmentNameAndCourse()
        {
            return aGetWay.GetStudentInfoWithDepartmentNameAndCourse();
        }

        public List<SCD> GetStudentInfoWithDepartmentNameAndCourseTrue()
        {
            return aGetWay.GetStudentInfoWithDepartmentNameAndCourseTrue();
        }
    }
}