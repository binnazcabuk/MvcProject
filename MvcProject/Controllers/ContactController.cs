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

            var inbox = _context.Messages.Count(x => x.ReceiverMail == "binnaz@gmail.com").ToString();
            ViewBag.inbox = inbox;

            var sendbox = _context.Messages.Count(x => x.SenderMail == "binnaz@gmail.com").ToString();
            ViewBag.sendbox= sendbox;


            return PartialView();
        }

    }
}