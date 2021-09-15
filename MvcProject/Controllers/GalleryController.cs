using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery

        ImageFileManager _imageFile = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = _imageFile.GetAll();
            return View(files);
        }
    }
}