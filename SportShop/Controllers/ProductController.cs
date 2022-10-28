using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportShop.Models;

namespace SportShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            DBSportStoreEntities WebDB = new DBSportStoreEntities();
            return View(WebDB.Products.ToList());
        }
    }
}