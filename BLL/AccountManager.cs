using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.BLL
{
    public class AccountManager
    {
        AccountGetWay accountGetWay = new AccountGetWay();
        public User CheckLogin(UserViewModel user)
        {
            return accountGetWay.CheckLogin(user);
        }
    }
}