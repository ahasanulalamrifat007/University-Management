using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class RoomManager
    {
        RoomGetWay aGetWay=new RoomGetWay();

        public List<Room> GetAllRooms()
        {
            return aGetWay.GetAllRooms();
        }
    }
}