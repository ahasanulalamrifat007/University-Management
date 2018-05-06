using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class AllocateClassRoomManager
    {
        AllocateClassRoomGetWay allocateClassRoomGetWay=new AllocateClassRoomGetWay();

        public int SaveAllocateClassRoom(AllocateClassroom allocate)
        {
            return allocateClassRoomGetWay.SaveAllocateClassRoom(allocate);
        }

        //public List<AllocateClassroom> GetAllRoomAllocation()
        //{
        //    return allocateClassRoomGetWay.GetAllRoomAllocation();
        //}
        //Try
        public bool GetRoomCheck(AllocateClassroom allocate)
        {
            return allocateClassRoomGetWay.GetRoomCheck(allocate);
        }
    }
}