using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class EnrollManager
    {
        EnrollGetWay aGetWay=new EnrollGetWay();

        public int EnrollCourse(Enroll aEnroll)
        {
            return aGetWay.EnrollCourse(aEnroll);
        }

        public List<Enroll> GetAllEnrollsByRegNo(String RegNo)
        {
            return aGetWay.GetAllEnrollsByRegNo(RegNo);
        }

        public List<Enroll> GetAllEnrollsByRegNoTrue(String RegNo)
        {
            return aGetWay.GetAllEnrollsByRegNoTrue(RegNo);
        }
    }
}