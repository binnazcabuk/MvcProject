using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    [AllowAnonymous]
    public class HomePageController : Controller
    {
        // GET: HomePage
        ContentManager _contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            Context _context = new Context();
            ViewModel viewModel = new ViewModel();
            viewModel.Headings = _context.Headings.ToList();
            viewModel.Contents = _context.Contents.ToList();

            return View(viewModel);
        }

       
    }
}