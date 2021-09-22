using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace MvcProject.Controllers
{
   [AllowAnonymous]
    public class LoginController : Controller
    {

        WriterLoginManager _writerLoginManager = new WriterLoginManager(new EfWriterDal());
        // GET: Login
        [HttpGet]
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin )
        {
            Context context = new Context();
            var adminuserinfo = context.Admins.FirstOrDefault(x => x.AdminUsername == admin.AdminUsername && x.AdminPassword == admin.AdminPassword);


            if(adminuserinfo!= null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUsername,false);
                Session["AdminUsername"] = adminuserinfo.AdminUsername;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }

          
        }
        [HttpGet]

     
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var writeruserinfo = _writerLoginManager.GetWriter(writer.WriterMail, writer.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }

           
           
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HomePage","Home" );
        }
    }
}