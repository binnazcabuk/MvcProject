using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel


        Context context = new Context();


        private HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult WriterProfile()
        {
           
          
           
            return View();
        }
        public ActionResult AllHeading()
        {
            var headings = _headingManager.GetAll();


            return View(headings);
        }
        public ActionResult MyHeading(string p)
        {
         
            p = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == p)
                .Select(y => y.WriterID).FirstOrDefault();

            var contentValues = _headingManager.GetAllByWriter(writeridinfo);
            return View(contentValues);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from category in _categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.category = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading )
        {
            string w = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == w)
                .Select(y => y.WriterID).FirstOrDefault();

            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writeridinfo;
            heading.HeadingStatus = true;
            _headingManager.Add(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {

            List<SelectListItem> valueCategory = (from category in _categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.category = valueCategory;
            var headingValue = _headingManager.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            heading.HeadingStatus = true;
            _headingManager.Update(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var reult = _headingManager.GetById(id);

            if (reult.HeadingStatus == true)
            {
                reult.HeadingStatus = false;
            }
            else
            {
                reult.HeadingStatus = true;

            }
            _headingManager.Delete(reult);
            return RedirectToAction("MyHeading");
        }
    }
}