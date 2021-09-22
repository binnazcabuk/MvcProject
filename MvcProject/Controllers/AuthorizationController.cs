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
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager _adminManager = new AdminManager(new EfAdminDal());
        //RoleManager rm = new RoleManager(new EFRoleDAL());

        public ActionResult Index()
        {
            var adminvalues = _adminManager.GetList();
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valueadminrole = (from c in _adminManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.AdminRole,
                                                       Value = c.AdminRole.ToString()

                                                   }).ToList();

            ViewBag.valueadmin = valueadminrole;

            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
           
            p.AdminStatus = true;
            _adminManager.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valueadminrole = (from c in _adminManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                      Text = c.AdminRole,
                                                      Value = c.AdminRole.ToString()

                                                   }).ToList();

            ViewBag.valueadmin = valueadminrole;
            var adminvalue = _adminManager.GetById(id);
            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
          _adminManager.AdminUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var result = _adminManager.GetById(id);
            if (result.AdminStatus == true)
            {
                result.AdminStatus = false;
            }
            else
            {
                result.AdminStatus = true;
            }
            _adminManager.AdminUpdate(result);
            return RedirectToAction("Index");
        }
    }
}