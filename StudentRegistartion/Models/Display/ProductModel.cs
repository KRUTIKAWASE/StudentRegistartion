using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistartion.Data;

namespace StudentRegistartion.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string ProdName { get; set; }
        public string Price { get; set; }
        public string Contact { get; set; }
        public string Image { get; set; }
        public string CompanyName { get; set; }

        public List<SpecialModel> GetList()
        {
            StudentEntities db = new StudentEntities();
            List<SpecialModel> lstProd = new List<SpecialModel>();

            var AddList = db.tblProducts.ToList();
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
    }
}