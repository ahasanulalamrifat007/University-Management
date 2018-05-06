using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemMVC.BLL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        
        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department aDepartment)
        {
            if (aDepartment.Code == null || aDepartment.Name == null)
            {
                ViewBag.message = "Input Values";
            }
            else
            {
                if (aDepartment.Code.Length < 2 || aDepartment.Code.Length > 7)
                {
                    ViewBag.message = "Code Length Must be 2 to 7 characters";
                }
                else
                {
                    List<Department> alist = aDepartmentManager.GetAllDepartmentInfo();
                    var departmnetcode = alist.FirstOrDefault(c => c.Code == aDepartment.Code);
                    var departmentname = alist.FirstOrDefault(n => n.Name == aDepartment.Name);
                    if (departmnetcode != null || departmentname != null)
                    {
                        if (departmnetcode != null && departmentname != null)
                        {
                            ViewBag.message = "Code and Name Already Exist";
                        }
                        else if(departmnetcode != null)
                        {
                            ViewBag.message = "Code Already Exist";
                        }
                        else if (departmentname != null)
                        {
                            ViewBag.message = "Name Already Exist";
                        }
                    }
                    else
                    {
                        if (aDepartmentManager.SaveDepartment(aDepartment) > 0)
                        {
                            ViewBag.message = "Department Saved Successfully";
                        }
                        else
                        {
                            ViewBag.message = "Save Failed";
                        }
                    }
                }
            }
            ModelState.Clear();
            return View();
        }

        public ActionResult ShowAllDepartment()
        {
            ViewBag.alldepartment=aDepartmentManager.GetAllDepartmentInfo();
            return View();
        }


    }
}