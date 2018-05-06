using System.Web.Mvc;
using UniversityManagementSystemMVC.BLL;
using UniversityManagementSystemMVC.Models;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.Controllers
{
    public class AccountController : Controller
    {
        AccountManager accountManager = new AccountManager();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                var currentUser = accountManager.CheckLogin(userLogin);
                if ( currentUser.Username==userLogin.Username &&
                    currentUser.Password == userLogin.Password)
                {
                    Session["CurrentUser"] = currentUser;
                    return RedirectToAction("Home", "Home");
                }
            }
            ViewBag.ErrorMsg = "Username or Password Error.";
            return View();
        }

        public ActionResult Logout()
        {
            Session["CurrentUser"] = null;
            return RedirectToAction("Home", "Home");
        }
    }
}