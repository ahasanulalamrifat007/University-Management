using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;

namespace UniversityManagementSystemMVC.BLL
{
    public class UnassignManager
    {
        UnassignGetWay aUnassignGetWay=new UnassignGetWay();

        public void UnassignCourse()
        {
            aUnassignGetWay.UnassignCourse();
        }
    }
}