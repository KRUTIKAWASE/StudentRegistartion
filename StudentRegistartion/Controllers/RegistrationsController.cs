using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentRegistartion.Data;

namespace StudentRegistartion.Controllers
{
    public class RegistrationsController : Controller
    {
        private StudentEntities db = new StudentEntities();

        // GET: Registrations
        public ActionResult Index()
        {
            return View(db.tblRegistrations.ToList());
        }

        // GET: Registrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegistration tblRegistration = db.tblRegistrations.Find(id);
            if (tblRegistration == null)
            {
                return HttpNotFound();
            }
            return View(tblRegistration);
        }

        // GET: Registrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudeID,StudName,Email,MobileNo,Address,State,Password,ID")] tblRegistration tblRegistration)
        {
            if (ModelState.IsValid)
            {
                db.tblRegistrations.Add(tblRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblRegistration);
        }

        // GET: Registrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegistration tblRegistration = db.tblRegistrations.Find(id);
            if (tblRegistration == null)
            {
                return HttpNotFound();
            }
            return View(tblRegistration);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudeID,StudName,Email,MobileNo,Address,State,Password,ID")] tblRegistration tblRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblRegistration);
        }

        // GET: Registrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegistration tblRegistration = db.tblRegistrations.Find(id);
            if (tblRegistration == null)
            {
                return HttpNotFound();
            }
            return View(tblRegistration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRegistration tblRegistration = db.tblRegistrations.Find(id);
            db.tblRegistrations.Remove(tblRegistration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
