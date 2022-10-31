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
        DBSportStoreEntities WebDB = new DBSportStoreEntities();
        // GET: Product
        //show all products
        public ActionResult Index(string _name)
        {
            
            if (_name == null)
                return View(WebDB.Products.ToList());
            else
                return View(WebDB.Products.Where(s => s.NamePro.Contains(_name)).ToList());
           
        }
        public ActionResult ProductDetail(int id)
        {
            return View(WebDB.Products.Where(s=>s.ProductID==id).FirstOrDefault());
        }
        
        public ActionResult bike()
        {
            return View(WebDB.Products.Where(s =>s.Category.Contains("BIKE")).ToList());
        }

        public ActionResult Fitness()
        {
            return View(WebDB.Products.Where(s => s.Category.Contains("DCTT")).ToList());
        }
        public ActionResult LeoNui()
        {
            return View(WebDB.Products.Where(s => s.Category.Contains("DCLN")).ToList());
        }
        public ActionResult CamTrai()
        {
            return View(WebDB.Products.Where(s => s.Category.Contains("DCDN")).ToList());
        }
        public ActionResult ChayBo()
        {
            return View(WebDB.Products.Where(s => s.Category.Contains("CHAY")).ToList());
        }
        public ActionResult TTDN()
        {
            return View(WebDB.Products.Where(s => s.Category.Contains("TTDN")).ToList());
        }
        public ActionResult TTDD()
        {
            return View(WebDB.Products.Where(s => s.Category.Contains("TTDD")).ToList());
        }
    }
}