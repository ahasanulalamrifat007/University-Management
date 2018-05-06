using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class StudentViewResultManager
    {
        StudentViewResultGetWay aGetWay=new StudentViewResultGetWay();

        public List<StudentViewResult> GetViewResult(string RegNo)
        {
            return aGetWay.GetViewResult(RegNo);
        }
    }
}