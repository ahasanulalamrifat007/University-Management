using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.BLL
{
    public class ViewAllocateClassRoomManager
    {
        ViewAllocateClassRoomGetWay allocateClassRoomGetWay=new ViewAllocateClassRoomGetWay();

        public List<ViewAllocateClassRoom> GetAllViewAllocatedClassRoom(int departmentId)
        {
            return allocateClassRoomGetWay.GetAllViewAllocatedClassRoom(departmentId);
        }
    }
}