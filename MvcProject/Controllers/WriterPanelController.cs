using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using PagedList;
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


        WriterValidator validationRules = new WriterValidator();
        Context context = new Context();


        private HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
           string p = (string)Session["WriterMail"];
            id = context.Writers.Where(x => x.WriterMail == p)
                .Select(y => y.WriterID).FirstOrDefault();


            var writervalue = writerManager.GetById(id);
           
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult results = validationRules.Validate(writer);
            if (results.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult AllHeading(int? page)
        {

            var headings = _headingManager.GetAll().ToPagedList(page ?? 1,4);
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