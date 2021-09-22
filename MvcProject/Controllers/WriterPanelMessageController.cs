using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcProject.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
     
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        MessageValidator _validations = new MessageValidator();

        public ActionResult Index()
        {
            return View();
        }

   
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            

            var messageList = _messageManager.GetAllInbox(p);
            return View(messageList);
        }
        public PartialViewResult MessagePartial() {


            string p = (string)Session["WriterMail"];
            var inbox = _messageManager.GetListUnRead(p).Count();
            ViewBag.inbox = inbox;

          var inbox2 = _messageManager.GetAllInbox(p).Count();
          ViewBag.inbox2 = inbox2;

            var trash = _messageManager.GetListTrash(p).Count();
            ViewBag.trash = trash;

            return PartialView();
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];

            var messageList = _messageManager.GetAllSendbox(p);
            return View(messageList);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string p = (string)Session["WriterMail"];

            ValidationResult result = _validations.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                message.MessageStatus = true;
                message.SenderMail = p;
                _messageManager.Add(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var contactValues = _messageManager.GetById(id);
            if (contactValues.IsRead == false)
            {
                contactValues.IsRead = true;
            }
            _messageManager.Update(contactValues);
            return View(contactValues);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var contactValues = _messageManager.GetById(id);
            return View(contactValues);
        }
        public ActionResult IsRead(int id)
        {
            var result = _messageManager.GetById(id);
            if (result.IsRead == false)
            {
                result.IsRead = true;
            }
            _messageManager.Update(result);
            return RedirectToAction("UnReadMessage");
        }

        public ActionResult UnReadMessage()
        {
            string p = (string)Session["WriterMail"];
            var unReadMessage = _messageManager.GetListUnRead(p);
            return View(unReadMessage);
        }

        public ActionResult TrashMessage()
        {
            string p = (string)Session["WriterMail"];
            var trashMessage = _messageManager.GetListTrash(p);
            return View(trashMessage);
        }
        public ActionResult GetTrashMessageDetails(int id)
        {
            var contactValues = _messageManager.GetById(id);
            return View(contactValues);
        }
        public ActionResult TrashMessageDelete(int id)
        {
            var r = _messageManager.GetById(id);
            _messageManager.TrashDelete(r);
            return RedirectToAction("TrashMessage");
        }

        public ActionResult MessageDelete(int id)
        {
            var reult = _messageManager.GetById(id);

            if (reult.MessageStatus == true)
            {
                reult.MessageStatus = false;
            }
            else
            {
                reult.MessageStatus = false;

            }
            _messageManager.Delete(reult);
            return RedirectToAction("Inbox");
        }
    }
}
