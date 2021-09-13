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
    public class MessageController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        MessageValidator _validations = new MessageValidator();
       
        public ActionResult Inbox()
        {
            
                
            var messageList = _messageManager.GetAllInbox();
            return View(messageList);
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
            return View(contactValues);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var contactValues = _messageManager.GetById(id);
            return View(contactValues);
        }
    }
}