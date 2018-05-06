using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemMVC.BLL;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult ViewClassroom()
        {
            DepartmentManager aDepartmentManager=new DepartmentManager();
            ViewBag.departmentlist = aDepartmentManager.GetAllDepartmentInfo();
            return View();
        }

        public JsonResult GetSchedule(int departmentId)
        {
            ViewAllocateClassRoomManager allocateClassRoomManager=new ViewAllocateClassRoomManager();
            var list = allocateClassRoomManager.GetAllViewAllocatedClassRoom(departmentId);
            var schedules = list.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(schedules, JsonRequestBehavior.AllowGet);
        }
    }
}