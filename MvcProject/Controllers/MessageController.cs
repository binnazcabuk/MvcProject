using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
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
        public ActionResult NewMessage(Message mesaj)
        {
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