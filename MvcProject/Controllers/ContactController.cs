using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager _contactManager = new ContactManager(new EfContactDal());
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        ContactValidator contactValidator = new ContactValidator();
        Context _context = new Context();

        public ActionResult Index()
        {
            var contactValues = _contactManager.GetAll();
            return View(contactValues);

            
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = _contactManager.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult ContactPartial(string p)
        {
            var contacts = _contactManager.GetAll().Count();
            ViewBag.contact = contacts;

            var inbox = _messageManager.GetListUnRead().Count();
            ViewBag.inbox = inbox;

            var inbox2 = _messageManager.GetAllInbox().Count();
            ViewBag.inbox2 = inbox2;

            var trash = _messageManager.GetListTrash().Count();
            ViewBag.trash = trash;

            return PartialView();
        }

    }
}