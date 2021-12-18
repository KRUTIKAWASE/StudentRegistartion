using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistartion.Models;

namespace StudentRegistartion.Controllers.Regis
{
    public class RegisController : Controller
    {
        // GET: Regis
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveRegis(RegisModel model)
        {
            try
            {
                return Json(new { message = (new RegisModel().SaveRegis(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetRegisModel()
        {
            try
            {
                return Json(new { model = (new RegisModel().GetRegisModel()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult deleteRegister(int StudeID)
        {
            try
            {
                return Json(new { model = (new RegisModel().deleteRegister(StudeID)) }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //public ActionResult GetEditData(int ID)
        //{
        //    try
        //    {
        //        return Json(new { model = (new RegisModel().EditData(ID)) }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}

    }
}