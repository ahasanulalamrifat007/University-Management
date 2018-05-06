using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class TeacherManager
    {
        TeacherGetWay aTeacherGetWay=new TeacherGetWay();

        public int SaveTeacher(Teacher aTeacher)
        {
            return aTeacherGetWay.SaveTeacher(aTeacher);
        }

        public List<Teacher> GetAllTeachers()
        {
            return aTeacherGetWay.GetAllTeachers();
        }

        public void updatecredit(double credit,int id)
        {
            aTeacherGetWay.updatecredit(credit, id);
        }
    }
}