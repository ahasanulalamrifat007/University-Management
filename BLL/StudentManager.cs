using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class StudentManager
    {
        StudentGetWay aStudentGetWay=new StudentGetWay();

        public int SaveStudent(Student aStudent)
        {
            
            return aStudentGetWay.SaveStudent(aStudent);
        }

        public List<Student> GetAllStudents()
        {
            return aStudentGetWay.GetAllStudents();
        }

        public string GetDepartmentCodeById(int departmentid)
        {
            return aStudentGetWay.GetDepartmentCodeById(departmentid);
        }

        //public int GetNo()
        //{
        //    return aStudentGetWay.GetNo();
        //}

        public int NoOfRegistraion()
        {
            return aStudentGetWay.NoOfRegistraion();
        }

        public int NoOfCodeAndYear(int number,string codeyear)
        {
            return aStudentGetWay.NoOfCodeAndYear(number,codeyear);
        }
    }
}