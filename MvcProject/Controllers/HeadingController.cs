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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager _writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValues = _headingManager.GetAll();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from category in _categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryID.ToString()
                                                  }).ToList();

            List<SelectListItem> valueWriter = (from writer in _writerManager.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = writer.WriterName + " " + writer.WriterSurName,
                                                    Value = writer.WriterID.ToString()
                                                }).ToList();
            ViewBag.category = valueCategory;
            ViewBag.writer = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            _headingManager.Add(heading);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = _headingManager.GetById(id);

            headingValue.HeadingStatus = false;
            _headingManager.Delete(headingValue);
            return RedirectToAction("Index");
        }

    }
}