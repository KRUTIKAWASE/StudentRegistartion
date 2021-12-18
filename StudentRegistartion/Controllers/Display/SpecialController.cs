using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistartion.Models;

namespace StudentRegistartion.Controllers.Display
{
    public class SpecialController : Controller
    {
        // GET: Special
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveProduct(SpecialModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];
                }
                return Json(new { message = (new SpecialModel().SaveProduct(fb,model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { model = Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetProductlist(string CompanyName)
        {
            try
            {
                return Json(new { model = (new SpecialModel().GetProductlist(CompanyName)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        
        public ActionResult deleteProduct(int ID)
        {
            try
            {
                return Json(new { model = (new SpecialModel().deleteProduct(ID)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}