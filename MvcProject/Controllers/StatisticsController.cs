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

        Context _context = new Context();
        public ActionResult Index()
        {
            //Toplam Kategori Sayisi
            var categoryCount = _context.Categories.Count().ToString();
            ViewBag.categorycount = categoryCount;

            // Yazilim Kategorisi (11) baslik sayisi
            var softwareCategoryCount = _context.Headings.Count(h => h.CategoryID == 11).ToString();
            ViewBag.softwareCategoryCount = softwareCategoryCount;

            // Yazar adinda "a" harfi gecen yazar sayisi
            var writerName = _context.Writers.Where(w => w.WriterName.Contains("a") || w.WriterName.Contains("A")).Count();
            ViewBag.writerName = writerName;


            // En fazla basliga sahip kategori adi
            var categoryHeader = _context.Categories.Where(u => u.CategoryID == _context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.categoryHeader = categoryHeader;

           

       

            return View();
        }
    }
}