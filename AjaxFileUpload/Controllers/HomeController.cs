using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxFileUpload.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase[] files, int id)
        {

            for (int i = 0; i < files.Length; i++)
            {
                var folder = Server.MapPath("~/Upload");
                var randomFileName = Path.GetRandomFileName();
                var filename = Path.ChangeExtension(randomFileName, ".jpg");
                var path = Path.Combine(folder, filename);

                files[i].SaveAs(path);
            }

            return Json("");
        }
    }
}