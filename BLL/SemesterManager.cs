using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class SemesterManager
    {
        SemesterGetWay aSemesterGetWay=new SemesterGetWay();
        public List<Semester> GetAllSemester()
        {
            return aSemesterGetWay.GetAllSemester();
        }
    }
}