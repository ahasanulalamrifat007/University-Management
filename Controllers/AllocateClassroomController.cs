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
    public class AllocateClassroomController : Controller
    {
        // GET: AllocateClassroom
        public ActionResult Allocate()
        {
            DepartmentManager aDepartmentManager = new DepartmentManager();
            RoomManager aRoomManager = new RoomManager();
            sevendaysManager aSevendaysManager = new sevendaysManager();
            ViewBag.aldepartments = aDepartmentManager.GetAllDepartmentInfo();
            ViewBag.allrooms = aRoomManager.GetAllRooms();
            ViewBag.sevendays = aSevendaysManager.GetAllDays();
            return View();
        }

        [HttpPost]
        public ActionResult Allocate(AllocateClassroom allocate)
        {
            DepartmentManager aDepartmentManager = new DepartmentManager();
            RoomManager aRoomManager = new RoomManager();
            sevendaysManager aSevendaysManager = new sevendaysManager();
            ViewBag.aldepartments = aDepartmentManager.GetAllDepartmentInfo();
            ViewBag.allrooms = aRoomManager.GetAllRooms();
            ViewBag.sevendays = aSevendaysManager.GetAllDays();
            AllocateClassRoomManager allocateClassRoomManager = new AllocateClassRoomManager();
            bool allocateRoom = allocateClassRoomManager.GetRoomCheck(allocate);

            if (allocate.From>allocate.To)
            {
                ViewBag.message = "Your Time Formate isn't Right";
            }

            else if (allocateRoom)
            {
                ViewBag.message = "Room Is Not Free";
            }
            else
            {
                if (allocateClassRoomManager.SaveAllocateClassRoom(allocate) > 0)
                {
                    ViewBag.message = "Room Is Allocated";
                }
                else
                {
                    ViewBag.message = "Failed To Allocated";
                }
            }
            
            return View();
        }



        public JsonResult GetCourseByDepartmentId(int departmentId)
        {

            CourseManager aCourseManager = new CourseManager();
            var courses = aCourseManager.GetAllCourse();
            var courselist = courses.Where(c => c.DepartmentId == departmentId).ToList();
            return Json(courselist, JsonRequestBehavior.AllowGet);
        }

    }
}