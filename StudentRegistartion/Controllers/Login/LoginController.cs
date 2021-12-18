using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using StudentRegistartion.Models;

namespace StudentRegistartion.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginIN(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "Admin" && model.Password == "admin@123")
                {

                    return RedirectToAction("..\\Product\\Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User name or password.");
                }

            }
            return View("..\\Login\\Index", model);
        }

        public ActionResult UserDashBoard()
        {
            //return View("..\\Login\\Index");
            return View("..\\Home\\Index");
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return View("..\\Login\\Index");
        }
    }
}