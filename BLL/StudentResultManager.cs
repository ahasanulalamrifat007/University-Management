using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class StudentResultManager
    {
        StudentResultGetWay aResultGetWay=new StudentResultGetWay();

        public int SaveStudentResult(StudentResult aStudentResult)
        {
            return aResultGetWay.SaveStudentResult(aStudentResult);
        }

        public List<StudentResult> GetAllStudentResultsByRegNo(string RegNo)
        {
            return aResultGetWay.GetAllStudentResultsByRegNo(RegNo);
        }
    }
}