using Business.Concrete;
using Business.ValidationRules;
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
            var messageList = _messageManager.GetAllInbox();
            return View(messageList);
        }
        public PartialViewResult MessagePartial() {

            

            var inbox = _messageManager.GetListUnRead().Count();
            ViewBag.inbox = inbox;

            var inbox2 = _messageManager.GetAllInbox().Count();
            ViewBag.inbox2 = inbox2;

            var trash = _messageManager.GetListTrash().Count();
            ViewBag.trash = trash;

            return PartialView();
        }

        public ActionResult Sendbox()
        {

            var messageList = _messageManager.GetAllSendbox();
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

            ValidationResult result = _validations.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                message.MessageStatus = true;
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
            var unReadMessage = _messageManager.GetListUnRead();
            return View(unReadMessage);
        }

        public ActionResult TrashMessage()
        {
            var trashMessage = _messageManager.GetListTrash();
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
