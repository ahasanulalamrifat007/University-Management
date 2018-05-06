using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using UniversityManagementSystemMVC.BLL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.Controllers
{
    public class EnrollController : Controller
    {
        // GET: Enroll
        public ActionResult EnrollCourse()
        {
            Enroll aEnroll=new Enroll();
            aEnroll.Date = DateTime.Today;
            StudentManager aStudentManager=new StudentManager();
            ViewBag.studentlist=aStudentManager.GetAllStudents();
            return View(aEnroll);
        }
        [HttpPost]
        public ActionResult EnrollCourse(Enroll aEnroll)
        {
            EnrollManager aEnrollManager=new EnrollManager();
            StudentManager aStudentManager = new StudentManager();
            ViewBag.studentlist = aStudentManager.GetAllStudents();
            var courselist = aEnrollManager.GetAllEnrollsByRegNo(aEnroll.StudentRegNo);
            var check = courselist.FirstOrDefault(a => a.CourseId == aEnroll.CourseId);

            var courselisttrue = aEnrollManager.GetAllEnrollsByRegNoTrue(aEnroll.StudentRegNo);
            var checktrue = courselisttrue.FirstOrDefault(a => a.CourseId == aEnroll.CourseId);

            if (aEnroll.CourseId == 0)
            {
                ViewBag.message = "Select Course";
            }
            else
            {
                if (checktrue != null)
                {
                    ViewBag.message = "This Course Already Assigned";
                }
                else
                {
                    aEnrollManager.EnrollCourse(aEnroll);
                    ViewBag.message = "Course Enrolled Successfully";
                }
                }

            return View(aEnroll);
        }


        public JsonResult GetStudentInfoByRegNo(string RegNo)
        {
            StudentDepartmentManager aStudentDepartmentManager=new StudentDepartmentManager();
            var studentdepartment = aStudentDepartmentManager.GetStudentInfoWithDepartmentName();
            var enrollcd = studentdepartment.FirstOrDefault(s => s.RegistrationNo == RegNo);
            return Json(enrollcd, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCoursesListByRegNo(string RegNo)
        {
            EnrollcdManager aEnrollcdManager = new EnrollcdManager();
            int departmentid = aEnrollcdManager.GetDepartmentIdByRegNo(RegNo);
            var enrollcds = aEnrollcdManager.GetAllGetAllCourseAndDepartmentCourse();
            var enrollcd = enrollcds.Where(a => a.DepartmentId == departmentid & a.RegistrationNo==RegNo).ToList();
            return Json(enrollcd, JsonRequestBehavior.AllowGet);
        }
    }
}