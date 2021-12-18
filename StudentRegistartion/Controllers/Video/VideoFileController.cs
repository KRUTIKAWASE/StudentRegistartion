using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistartion.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace StudentRegistartion.Controllers
{
    public class VideoFileController : Controller
    {
        // GET: VideoFile
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadVideo()
        {
            List<VideoFileModel> videolist = new List<VideoFileModel>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetAllVideoFile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    VideoFileModel video = new VideoFileModel();
                    video.ID = Convert.ToInt32(rdr["ID"]);
                    video.Name = rdr["Name"].ToString();
                    video.FileSize = Convert.ToInt32(rdr["FileSize"]);
                    video.FilePath = rdr["FilePath"].ToString();

                    videolist.Add(video);
                }
            }
            return View(videolist);
        }

        [HttpPost]
        public ActionResult UploadVideo(HttpPostedFileBase fileupload)
        {
            if (fileupload != null)
            {
                string fileName = Path.GetFileName(fileupload.FileName);
                int fileSize = fileupload.ContentLength;
                int Size = fileSize / 1000;
                fileupload.SaveAs(Server.MapPath("~/VideoFileUpload/" + fileName));

                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spAddNewVideoFile", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Name", fileName);
                    cmd.Parameters.AddWithValue("@FileSize", Size);
                    cmd.Parameters.AddWithValue("FilePath", "~/VideoFileUpload/" + fileName);
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction("UploadVideo");
        }
    }
}