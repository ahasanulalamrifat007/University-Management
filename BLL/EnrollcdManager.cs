using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.BLL
{
    public class EnrollcdManager
    {
        EnrollcdGetWay aEnrollcdGetWay=new EnrollcdGetWay();

        public List<Enrollcd> GetAllGetAllCourseAndDepartmentCourse()
        {
            return aEnrollcdGetWay.GetAllCourseAndDepartment();
        }

        public int GetDepartmentIdByRegNo(string RegNo)
        {
            return aEnrollcdGetWay.GetDepartmentIdByRegNo(RegNo);
        }
    }
}