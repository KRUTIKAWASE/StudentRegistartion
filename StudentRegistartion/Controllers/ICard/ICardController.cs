using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistartion.Models;

namespace StudentRegistartion.Controllers
{
    public class ICardController : Controller
    {
        // GET: ICard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult saveICard(ICardModel model)
        {
            try
            {
                return Json(new { message = new ICardModel().saveICard(model) }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception Ex)
            {
                return Json(new { model = Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}