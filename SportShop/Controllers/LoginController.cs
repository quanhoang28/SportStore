using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop.Controllers
{
    
    public class LoginController : Controller
    {
        DBSportStoreEntities database = new DBSportStoreEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult LoginAccount(AdminUser _user)
        {
            var check = database.AdminUsers.Where(s => s.gmail==_user.gmail && s.PasswordUser==_user.PasswordUser).FirstOrDefault();
            if(check==null)
            {
                ViewBag.ErrorInfo = "Sai thông tin !";
                return View("Index");
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["gmail"] = _user.gmail;
                Session["PasswordUser"] = _user.PasswordUser;
                return RedirectToAction("Index", "Product");
            }
        }
    }
   
}