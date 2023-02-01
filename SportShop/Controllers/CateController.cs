using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportShop.Models;

namespace SportShop.Controllers
{
    public class CateController : Controller
    {
        DBSportStoreEntities6 database = new DBSportStoreEntities6();
        
        // GET: Cate
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult CategoryPartial()
        {
            var category = database.Categories.ToList();
            return PartialView(category);
        }
        public PartialViewResult ManagerCate()
        {
            var category = database.Categories.ToList();
            return PartialView(category);
        }
    }
}