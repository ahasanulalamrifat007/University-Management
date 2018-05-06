using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class DesignationManager
    {
        DesignationGetWay aDesignationGetWay=new DesignationGetWay();
        public List<Designation> GetAllDesignations()
        {
            return aDesignationGetWay.GetAllDesignations();
        }
    }
}