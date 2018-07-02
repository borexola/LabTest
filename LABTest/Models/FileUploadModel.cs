using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace LABTest.Models
{
    public class FileUploadModel
    {
        [Required]
        HttpPostedFileBase httpPostedFileBase { get; set; }

        public bool Uploaded { get; set; }

        public int? Leader { get; set; }

        public string Message { get; set; }
    }
}