using Business.Concrete;
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

        private HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading()
        {
          
            var result = _headingManager.GetAllByWriter();
            return View(result);
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
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = 4;
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