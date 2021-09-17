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
    public class MyTalentController : Controller
    {
        // GET: MyTalent
        private MyTalentManager myTalentManager = new MyTalentManager(new EfMyTalentDal());

        public ActionResult Index()
        {
            var result = myTalentManager.GetAll();
            return View(result);
        }

       

        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = myTalentManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(MyTalent myTalent)
        {
            myTalentManager.Update(myTalent);
            return RedirectToAction("Index");
        }
    

    }
}