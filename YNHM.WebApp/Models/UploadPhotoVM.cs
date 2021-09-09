using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YNHM.WebApp.Models
{
    public class UploadPhotoVM
    {
        public string Username { get; set; }
        public string Image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}