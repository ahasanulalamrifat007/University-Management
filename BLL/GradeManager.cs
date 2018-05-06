using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class GradeManager
    {
        GradeGetWay aGradeGetWay=new GradeGetWay();

        public List<Grade> GetAllGrades()
        {
            return aGradeGetWay.GetAllGrades();
        }
    }
}