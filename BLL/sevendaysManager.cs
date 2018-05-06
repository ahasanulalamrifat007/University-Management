using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class sevendaysManager
    {
        sevendaysGetWay aSevendaysGetWay=new sevendaysGetWay();

        public List<sevendays> GetAllDays()
        {
            return aSevendaysGetWay.GetAllDays();
        }
    }
}