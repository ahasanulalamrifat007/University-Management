using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Services.Description;
using UniversityManagementSystemMVC.BLL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.Controllers
{
    public class CourseAssignToTeacherController : Controller
    {
        // GET: CourseAssignToTeacher
        public ActionResult AssignToTeacher()
        {
            DepartmentManager aDepartmentManager = new DepartmentManager();
            ViewBag.departments = aDepartmentManager.GetAllDepartmentInfo();
            return View();
        }

        [HttpPost]
        public ActionResult AssignToTeacher(CourseAssignToTeacher assign)
        {
            Teacher aTeacher=new Teacher();
            DepartmentManager aDepartmentManager = new DepartmentManager();
            CourseAssignToTeacherManager assignToTeacherManager = new CourseAssignToTeacherManager();
            TeacherManager aTeacherManager = new TeacherManager();
            ViewBag.departments = aDepartmentManager.GetAllDepartmentInfo();
            aTeacherManager.GetAllTeachers();
            if (aTeacher.RemainingCredit < assign.CourseCredit)
            {
                
            }
            var assinglist = assignToTeacherManager.GetAllCourseassinAssignToTeachers();
            var assingcoursttoteacher = assinglist.FirstOrDefault(t => t.CourseId == assign.CourseId);
            var assigntrue = assignToTeacherManager.GetAllCourseassinAssignToTeachersTrue();
            var assigntruefind = assigntrue.FirstOrDefault(c => c.CourseId == assign.CourseId);
            var assignfalse = assignToTeacherManager.GetAllCourseassinAssignToTeachersFalse();
            var assigntfalsefind = assignfalse.FirstOrDefault(c => c.CourseId == assign.CourseId);

            if (assign.CourseCredit == 0.0)
            {
                ViewBag.message = "Input Values";
            }
            else
            {
                if (assigntruefind != null)
                {
                    ViewBag.message = "Course Already Assigned";
                }
                else if (assigntfalsefind !=null)
                {
                    if (assignToTeacherManager.UpdateAssignCourse(assign) > 0)
                        {
                            ViewBag.message = "Assign Successfull";
                        }
                        else
                        {
                            ViewBag.message = "Assign Failed";
                        }
                }
                else
                {
                    if (assignToTeacherManager.AssignCourseToTeacher(assign) > 0)
                    {
                        assignToTeacherManager.UpdateRemainingCredit(assign.CourseCredit, assign.TeacherId);

                        ViewBag.message = "Assign Successfull";
                    }
                    else
                    {
                        ViewBag.message = "Failed to Assign";
                    }
                }
            }
            return View();
        }

    public JsonResult GetTeachersByDepartmentId(int departmentId)
        {
            TeacherManager aTeacherManager = new TeacherManager();
            var teachers = aTeacherManager.GetAllTeachers();
            var teacherlist = teachers.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(teacherlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            CourseManager aCourseManager=new CourseManager();
            var courses = aCourseManager.GetAllCourse();
            var courselist = courses.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(courselist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTeacherInfoById(int Tid)
        {
            TeacherManager aTeacherManager=new TeacherManager();
            var teachers=aTeacherManager.GetAllTeachers();
            var teacher = teachers.FirstOrDefault(a => a.Id == Tid);
            return Json(teacher, JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetCourseInfoById(int Cid)
        {
            CourseManager aCourseManager=new CourseManager();
            var courseslist = aCourseManager.GetAllCourse();
            var course = courseslist.FirstOrDefault(c => c.Id == Cid);
            return Json(course, JsonRequestBehavior.AllowGet);
        }

    }
}