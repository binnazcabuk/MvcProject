using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
      
        Context _context = new Context();
        HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager _contentManager = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var headinglist = _headingManager.GetAll();

         
            return View(headinglist);
        }

        public PartialViewResult Index(int id=0)
        {
            var contentlist = _contentManager.GetAllByHeadingId(id);
            
            return PartialView(contentlist);
        }
    }
}