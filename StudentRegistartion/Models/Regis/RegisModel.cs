using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistartion.Data;

namespace StudentRegistartion.Models
{
    public class RegisModel
    {
        public int StudeID { get; set; }
        public string StudName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }

        public string SaveRegis(RegisModel model)
        {
            string msg = "";
            StudentEntities db = new StudentEntities();

            //var getCatData = db.tblRegistrations.Where(p => p.ID == model.ID).FirstOrDefault();
            //if (getCatData == null)
            //{
                var saveData = new tblRegistration()
                {
                    StudName = model.StudName,
                    Email = model.Email,
                    MobileNo = model.MobileNo,
                    Address = model.Address,
                    State = model.State,
                    Password = model.Password,
                };
                db.tblRegistrations.Add(saveData);
                db.SaveChanges();
                return msg;
            //}
            //else
            //{
            //    getCatData.StudName = model.StudName;
            //    getCatData.Email = model.Email;
            //    getCatData.MobileNo = model.MobileNo;
            //    getCatData.Address = model.Address;
            //    getCatData.State = model.State;
            //    getCatData.Password = model.Password;
            //};
            //db.SaveChanges();
            //msg = "Updated Sucessfully";
            //return msg;
        }
    

        public List<RegisModel> GetRegisModel()
        {
            StudentEntities db = new StudentEntities();
            List<RegisModel> lstStud = new List<RegisModel>();

            var AddList = db.tblRegistrations.ToList();
            if (AddList != null)
            {
                foreach (var test in AddList)
                {
                    lstStud.Add(new RegisModel()
                    {
                        StudeID = test.StudeID,
                        StudName = test.StudName,
                        Email = test.Email,
                        MobileNo = test.MobileNo,
                        Address = test.Address,
                        State = test.State,
                        Password = test.Password,
                    });
                }
            }
            return lstStud;
        }

        public string deleteRegister(int Id)
        {
            string msg = "";
            StudentEntities db = new StudentEntities();

            var deleteRecord = db.tblRegistrations.Where(p => p.StudeID == Id).FirstOrDefault();
            if( deleteRecord != null)
            {
                db.tblRegistrations.Remove(deleteRecord);
            }
            db.SaveChanges();
            return msg;
        }

        //public RegisModel EditData(int Id)
        //{
        //    string Message = "";
        //    RegisModel model = new RegisModel();
        //    StudentEntities Db = new StudentEntities();
        //    var editData = Db.tblRegistrations.Where(p => p.ID == Id).FirstOrDefault();
        //    if (editData != null)
        //    {
        //        model.ID = editData.ID;
        //        model.StudName = editData.StudName;
        //        model.Email = editData.Email;
        //        model.MobileNo = editData.MobileNo;
        //        model.Address = editData.Address;
        //        model.State = editData.State;
        //        model.Password = editData.Password;
        //    }
        //    Message = "Record Deleted Successfully";
        //    return model;
        //}
    }
}