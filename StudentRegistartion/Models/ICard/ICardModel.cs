using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistartion.Data;

namespace StudentRegistartion.Models
{
    public class ICardModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string DOB { get; set; }
        public string Expierd { get; set; }
        public string Photo { get; set; }

        public string saveICard(ICardModel model)
        {
            string msg = "";
            StudentEntities db = new StudentEntities();

            var saveStud = new tblICard()
            {
                Name = model.Name,
                Designation = model.Designation,
                DOB = model.DOB,
                Expierd = model.Expierd,
                Photo = model.Photo,
            };
            db.tblICards.Add(saveStud);
            db.SaveChanges();
            return msg;
        }
    }
}