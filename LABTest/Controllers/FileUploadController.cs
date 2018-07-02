using LABTest.App_Code;
using LABTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABTest.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload/upload
        [Route("Fileupload/Upload")]
        public ActionResult Index()
        {
            FileUploadModel fileUploadModel = new FileUploadModel
            {
                Message = string.Empty,
                Leader = -1,
                Uploaded = false

            };

            return View("Upload", fileUploadModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Fileupload/Upload")]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            FileUploadModel fileModel = new FileUploadModel
            {
                Uploaded = false,
                Leader = null,
                Message = "File upload failed"
            };

            try
            {
                if (file == null)
                {
                    fileModel.Message = "No File Specified!";
                }
                else if (Path.GetExtension(file.FileName).ToLower() != ".csv")
                {
                    fileModel.Message = "File must be a CSV file!";
                }
                else if (file.ContentLength <= 0)
                {
                    fileModel.Message = "File is empty!";
                }
                else
                {
                    //Save the file
                    string saveLocation = Path.Combine(Server.MapPath("~/uploads"), file.FileName);
                    file.SaveAs(saveLocation);

                    fileModel.Message = "File Upload Complete!";
                    fileModel.Uploaded = true;
                    fileModel.Leader = LeaderClass.GetLeader(saveLocation);
                }
            }
            catch (Exception ex)
            {
                fileModel.Message = $"File Upload Failed {ex.Message}";
            }

            return View("Upload", fileModel);
        }
    }
}