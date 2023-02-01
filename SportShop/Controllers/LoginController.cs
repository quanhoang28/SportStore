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
        DBSportStoreEntities6 database = new DBSportStoreEntities6();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
      
       
        [HttpPost]
        public ActionResult LoginAccount(AdminUser _user)
        {
            
            var check = database.AdminUsers.Where(s=>s.gmail==_user.gmail && s.PasswordUser==_user.PasswordUser).FirstOrDefault();
            if(check==null)
            {
                ViewBag.ErrorInfo = "Sai thông tin !";
                return View("Index");
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["ID"] = check.ID;
                Session["NameUser"] = check.NameUser;
                Session["PhoneNumber"] = check.PhoneNumber;
                Session["Gmail"] = check.gmail;
                Session["RoleUser"] = check.RoleUser;
                return RedirectToAction("Index", "Product");
            }
        }
        public ActionResult CustomerInfor(AdminUser _user)
        {
            return View(database.AdminUsers.Where(s => s.ID == _user.ID).FirstOrDefault());
        }
        public ActionResult Logout()
        {
            Session["NameUser"] = null;
            return RedirectToAction("Index", "Product");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AdminUser _user)
        {
            if (ModelState.IsValid)
            {
                var check_mail = database.AdminUsers.Where(s => s.gmail == _user.gmail).FirstOrDefault();
                if (check_mail == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.AdminUsers.Add(_user);
                    database.SaveChanges();
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ViewBag.ErrorRegister = "Mail đã tồn tại, vui lòng nhập mail khác";
                    return View();
                }
            }
            return View();
        }
        public ActionResult OrderHistory(AdminUser user)
        {
            user.ID = (int)Session["ID"];
            var model = (
                         from a in database.OrderProes
                         join b in database.OrderDetails on a.ID equals b.IDOrder
                         join p in database.Products on b.IDProduct equals p.ProductID
                         orderby a.DateOrder descending
                         select new ViewModel()
                         {
                            
                             CustomerId = (int)a.IDCus,
                             namePro = p.NamePro,
                             address = a.AddressDeliverry,
                             dateOrder = (DateTime)a.DateOrder,
                             Quant = (int)b.Quantity,
                             pricePro = (int)b.UnitPrice

                         }
                       ).Where(s=>s.CustomerId==user.ID);
            return View(model);
            
        }
    }
   
}