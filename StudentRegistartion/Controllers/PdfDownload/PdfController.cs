using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml;
using StudentRegistartion.Models;
using StudentRegistartion.Data;

namespace StudentRegistartion.Controllers
{
    public class PdfController : Controller
    {
        // GET: Pdf
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload(FormCollection formCollection)
        {
            var contactList = new List<PdfModel>();
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var worksheet = currentSheet.First();
                        var noOfCal = worksheet.Dimension.End.Column;
                        var noOfRow = worksheet.Dimension.End.Row;

                        using (StudentEntities dbEntities = new StudentEntities())
                        {
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                var user = new tblContact();
                                user.Name = worksheet.Cells[rowIterator, 1].Value.ToString();
                                user.Address = worksheet.Cells[rowIterator, 2].Value.ToString();
                                user.Phone = worksheet.Cells[rowIterator, 3].Value.ToString();
                                user.Email = worksheet.Cells[rowIterator, 4].Value.ToString();
                                dbEntities.tblContacts.Add(user);
                                dbEntities.SaveChanges();
                            }
                        }
                    }
                }
            }
            return View("Index");
        }    
    }
}