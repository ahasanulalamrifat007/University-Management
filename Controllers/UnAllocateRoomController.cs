using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemMVC.BLL;

namespace UniversityManagementSystemMVC.Controllers
{
    public class UnAllocateRoomController : Controller
    {
        // GET: UnAllocateRoom
        public ActionResult UnAllocate()
        {
            return View();
        }
        public void UnAllocateClassRooms()
        {
           UnAllocateManager allocateManager=new UnAllocateManager();
            allocateManager.UnAllocateRooms();
            //return Json(JsonRequestBehavior.AllowGet);
        }
    }
}