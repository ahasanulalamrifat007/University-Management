using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.BLL
{
    public class StudentDepartmentManager
    {
        StudentDepartmentGetWay aDepartmentGetWay=new StudentDepartmentGetWay();

        public List<StudentDepartment> GetStudentInfoWithDepartmentName()
        {
            return aDepartmentGetWay.GetStudentInfoWithDepartmentName();
        }
    }
}