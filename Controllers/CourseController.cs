using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemMVC.BLL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.Controllers
{
    public class CourseController : Controller
    {
        
        public ActionResult SaveCourse()
        {
            DepartmentManager aDepartmentManager=new DepartmentManager();
            SemesterManager aSemesterManager=new SemesterManager();
            ViewBag.departments=aDepartmentManager.GetAllDepartmentInfo();
            ViewBag.semesters = aSemesterManager.GetAllSemester();
            Course aCourse=new Course();
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourse(Course aCourse)
        {
            DepartmentManager aDepartmentManager = new DepartmentManager();
            SemesterManager aSemesterManager = new SemesterManager();
            ViewBag.departments = aDepartmentManager.GetAllDepartmentInfo();
            ViewBag.semesters = aSemesterManager.GetAllSemester();
            CourseManager aCourseManager=new CourseManager();
            if (aCourse.Credit == 0.0 || aCourse.Code == null || aCourse.Name == null || aCourse.DepartmentId == 0 ||
                aCourse.SemesterId == 0)
            {
                ViewBag.message = "Input Values";
            }
            else
            {
                if(aCourse.Code.Length<5||(aCourse.Credit<0.5||aCourse.Credit>5.0))
                {
                    if (aCourse.Code.Length < 5 && (aCourse.Credit < 0.5 || aCourse.Credit > 5.0))
                    {
                        ViewBag.message = "Code length must be at least 5 characters and \n Credit range is from 0.5 to 5.0";
                    }

                    else if (aCourse.Code.Length < 5)
                    {
                        ViewBag.message = "Code length must be at least 5 characters";
                    }
                    else if (aCourse.Credit < 0.5 || aCourse.Credit > 5.0)
                    {
                        ViewBag.message="Credit range is from 0.5 to 5.0";
                    }
                }
                else
                {
                    List<Course> alist = aCourseManager.GetAllCourse();
                    var coursecode=alist.FirstOrDefault(c => c.Code == aCourse.Code);
                    var coursename = alist.FirstOrDefault(n => n.Name == aCourse.Name);
                    if (coursecode != null || coursename != null)
                    {
                        if (coursecode != null && coursename != null)
                        {
                            ViewBag.message = "Code and Name Already Exist";
                        }
                        else if (coursecode != null)
                        {
                            ViewBag.message = "Code Already Exist";
                        }
                        else if (coursename != null)
                        {
                            ViewBag.message = "Name Already Exist";
                        }
                    }
                    else
                    {
                        if (aCourseManager.SaveCourse(aCourse)>0)
                        {
                            ViewBag.message = "Course Saved Successfully";
                        }
                        else
                        {
                            ViewBag.message = "Save Failed";
                        }
                    }
                }
            }
            return View();
        }


    }
}