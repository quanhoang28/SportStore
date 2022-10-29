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
        //show all products
        public ActionResult Index(string _name)
        {
            DBSportStoreEntities WebDB = new DBSportStoreEntities();
            if (_name == null)
                return View(WebDB.Products.ToList());
            else
                return View(WebDB.Products.Where(s => s.NamePro.Contains(_name)).ToList());
           
        }
        
        
    }
}