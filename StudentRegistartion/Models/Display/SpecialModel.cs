using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using StudentRegistartion.Data;

namespace StudentRegistartion.Models
{
    public class SpecialModel
    {
        public int ID { get; set; }
        public string ProdName { get; set; }
        public string Price { get; set; }
        public string Contact { get; set; }
        public string Image { get; set; }
        public string CompanyName { get; set; }

        public string SaveProduct(HttpPostedFileBase fb, SpecialModel model)
        {
            string msg = "";
            StudentEntities db = new StudentEntities();

            string filePath = "";
            string fileName = "";
            string sysFileName = "";

            if (fb != null && fb.ContentLength > 0)
            {

                //filePath = HttpContext.Current.Server.MapPath("~/Content/Pages/images/");
                filePath = HttpContext.Current.Server.MapPath("~/Content/Images/");
                DirectoryInfo di = new DirectoryInfo(filePath);
                if (!di.Exists)
                {
                    di.Create();
                }
                fileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                fb.SaveAs(filePath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("~/Content/Images/") + "/" + sysFileName;
                }
            }
            var saveData = new tblProduct()
            {
                ProdName = model.ProdName,
                Price = model.Price,
                Contact = model.Contact,
                Image = sysFileName,
                CompanyName = model.CompanyName,
            };
            db.tblProducts.Add(saveData);
            db.SaveChanges();
            return msg;
        }

        public List<SpecialModel> GetProductlist(string CompanyName)
        {
            StudentEntities db = new StudentEntities();
            List<SpecialModel> lstProd = new List<SpecialModel>();

            var AddList = db.tblProducts.Where(p => p.CompanyName == CompanyName).ToList();
            if (AddList != null)
            {
                foreach (var product in AddList)
                {
                    lstProd.Add(new SpecialModel()
                    {
                        ID = product.ID,
                        ProdName = product.ProdName,
                        Price = product.Price,
                        Contact = product.Contact,
                        Image = product.Image,
                        CompanyName = product.CompanyName,
                    });
                }
            }
            return lstProd;
        }

        

        public string deleteProduct(int Id)
        {
            string msg = "";
            StudentEntities db = new StudentEntities();

            var deleteData = db.tblProducts.Where(p => p.ID == Id).FirstOrDefault();
            if (deleteData != null)
            {
                db.tblProducts.Remove(deleteData);
            }
            db.SaveChanges();
            return msg;
        }
    }
}