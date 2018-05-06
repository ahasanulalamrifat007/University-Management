using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemMVC.BLL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.Controllers
{
    public class UnassignCourseController : Controller
    {
        // GET: UnassignCourse
        public ActionResult Unassign()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Unassign(Student aStudent)
        {
            return View();
        }
        public void UnassignAllCourses()
        {
            UnassignManager aUnassignManager = new UnassignManager();
            aUnassignManager.UnassignCourse();
            TeacherManager aTeacherManager=new TeacherManager();
            var list = aTeacherManager.GetAllTeachers();
            foreach (var teacher in list)
            {
                if (teacher.RemainingCredit < teacher.CreditTobeTaken)
                {
                    aTeacherManager.updatecredit(teacher.CreditTobeTaken,teacher.Id);
                }
                
            }
            //return Json(JsonRequestBehavior.AllowGet);
        }
    }
}