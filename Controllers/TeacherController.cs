using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemMVC.BLL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.Controllers
{
    public class TeacherController : Controller
    {
        
        public ActionResult SaveTeacher()
        {
            DesignationManager aDesignationManager=new DesignationManager();
            DepartmentManager aDepartmentManager=new DepartmentManager();
            ViewBag.designations=aDesignationManager.GetAllDesignations();
            ViewBag.departments = aDepartmentManager.GetAllDepartmentInfo();
            return View();
        }
        [HttpPost]
        public ActionResult SaveTeacher(Teacher aTeacher)
        {
            DesignationManager aDesignationManager = new DesignationManager();
            DepartmentManager aDepartmentManager = new DepartmentManager();
            TeacherManager aTeacherManager = new TeacherManager();
            ViewBag.designations = aDesignationManager.GetAllDesignations();
            ViewBag.departments = aDepartmentManager.GetAllDepartmentInfo();

            if (aTeacher.Name == null || aTeacher.Address == null || aTeacher.Email == null ||
                aTeacher.ContactNo == null || aTeacher.DesignationId == 0 || aTeacher.DepartmentId == 0 ||
                aTeacher.CreditTobeTaken == 0.0)
            {
                ViewBag.message = "Input Values";
            }
            else
            {
                List<Teacher> aList = aTeacherManager.GetAllTeachers();
                var teacheremail = aList.FirstOrDefault(e => e.Email == aTeacher.Email);

                if (aTeacher.CreditTobeTaken < 0 || teacheremail != null)
                {
                    if (aTeacher.CreditTobeTaken < 0 && teacheremail != null)
                    {
                        ViewBag.message = "Credit must contain a non-negative value And Email Already Exist";
                    }
                    else if (aTeacher.CreditTobeTaken < 0)
                    {
                        ViewBag.message = "Credit must contain a non-negative value";
                    }
                    else if (teacheremail != null)
                    {
                        ViewBag.message = "Email Already Exist";
                    }
                }
                else
                {
                    if (aTeacherManager.SaveTeacher(aTeacher) > 0)
                    {
                        ViewBag.message = "Teacher Saved Successfully";
                    }
                    else
                    {
                        ViewBag.message = "Save Failed";
                    }
                }
            }

            return View();
        }
    }
}