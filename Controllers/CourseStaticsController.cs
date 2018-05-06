using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemMVC.BLL;
using UniversityManagementSystemMVC.Models;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.Controllers
{
    public class CourseStaticsController : Controller
    {
        // GET: CourseStatics
        public ActionResult ViewCourseStatics()
        {
            DepartmentManager aDepartmentManager = new DepartmentManager();
            ViewBag.departments = aDepartmentManager.GetAllDepartmentInfo();
            return View();
        }
        [HttpPost]
        public ActionResult ViewCourseStatics(CourseStatics aCourseStatics)
        {
            DepartmentManager aDepartmentManager = new DepartmentManager();
            CourseStaticManager aCourseStaticManager = new CourseStaticManager();
            ViewBag.departments = aDepartmentManager.GetAllDepartmentInfo();
            ViewBag.coursestatics = aCourseStaticManager.GetAllCourseStaticses();
            var courselist = aCourseStaticManager.GetAllCourseStaticsesbyDepartmentId(aCourseStatics.DepartmentId);
            ViewBag.clist = courselist;
            return View();
        }
    }
}