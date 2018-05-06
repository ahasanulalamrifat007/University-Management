using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class DepartmentManager
    {
        DepartmentGetWay aDepartmentGetWay = new DepartmentGetWay();
        public List<Department> GetAllDepartmentInfo()
        {
            return aDepartmentGetWay.GetAllDepartmentInfo();
        }

        public int SaveDepartment(Department aDepartmentClass)
        {
            return aDepartmentGetWay.SaveDepartment(aDepartmentClass);
        }
    }
}