using System.Web.Mvc;
using System.Web.Security;
using VendingMachine.Models;

namespace VendingMachine.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Форма не валидна";
                return View("Login");
            }
            if (login.UserName == "admin" && login.Password == "superadmin")
                FormsAuthentication.RedirectFromLoginPage(login.UserName, true);
            ViewBag.Error = "Не привильный логин или пароль";
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("BeveragesIndex", "Admin");
        }
    }
}