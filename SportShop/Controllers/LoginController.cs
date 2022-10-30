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
       
       
    }
   
}