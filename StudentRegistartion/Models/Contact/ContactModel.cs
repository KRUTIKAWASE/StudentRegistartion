using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistartion.Data;

namespace StudentRegistartion.Models
{
    public class ContactModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string SaveContact(ContactModel model)
        {
            string msg = "";
            StudentEntities db = new StudentEntities();

            var saveData = new tblContact()
            {
                Name = model.Name,
                Address = model.Address,
                Phone = model.Phone,
                Email = model.Email,
            };
            db.tblContacts.Add(saveData);
            db.SaveChanges();
            return msg;
        }
    }
}