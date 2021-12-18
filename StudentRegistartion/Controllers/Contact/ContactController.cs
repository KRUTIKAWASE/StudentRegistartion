using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistartion.Models;

namespace StudentRegistartion.Controllers.Contact
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveContact(ContactModel model)
        {
            try
            {
                return Json(new { message = new ContactModel().SaveContact(model) }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception Ex)
            {
                return Json(new { model = Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}