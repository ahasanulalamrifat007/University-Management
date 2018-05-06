using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;

namespace UniversityManagementSystemMVC.BLL
{
    public class UnAllocateManager
    {
        UnAllocateGetWay allocateGetWay=new UnAllocateGetWay();

        public void UnAllocateRooms()
        {
            allocateGetWay.UnAllocateRooms();
        }
    }
}