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
    public class StatisticsController : Controller
    {
        // GET: Statistics

        Context context = new Context();
        public ActionResult Index()
        {
            var categorycount = context.Categories.Count().ToString();
            ViewBag.categorycount = categorycount;

            var softwarecategorycount = context.Headings.Count(h => h.CategoryID == 2).ToString();

            return View();
        }
    }
}