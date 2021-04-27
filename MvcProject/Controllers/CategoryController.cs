using Business.Abstract;
using Business.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager();


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = categoryManager.GetAll();
            return View(categoryvalues);
        }

        public ActionResult AddCategory(Category category)
        {
            categoryManager.Add(category);
            return RedirectToAction("GetCategoryList");
        }
    }
}