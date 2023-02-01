using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportShop.Models;
using PagedList;
using PagedList.Mvc;

namespace SportShop.Controllers
{
    public class ProductController : Controller
    {
        DBSportStoreEntities6 WebDB = new DBSportStoreEntities6();
        Product pro = new Product();
        
        
        // GET: Product
        //show all products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductDetail(int id)
        {
            return View(WebDB.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }

        public PartialViewResult ProductList(string _name, string category, int? page, double min = double.MinValue, double max = double.MaxValue)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);
          
            if (_name != null)
                return PartialView(WebDB.Products.Where(s => s.NamePro.Contains(_name)&&s.soldOut==false).OrderByDescending(s => s.NamePro).ToPagedList(pageNum, pageSize));

            else if (category != null)
                return PartialView(WebDB.Products.Where(s =>( (s.Category == category) || (s.Category2 == category)&&s.soldOut==false)).OrderByDescending(s => s.NamePro).ToPagedList(pageNum, pageSize));
            else if (max != 0 && min != 0)
            {
                var List = WebDB.Products.Where(s => (double)s.Price >= min && (double)s.Price <= max &&s.soldOut==false).OrderByDescending(s=>s.NamePro).ToPagedList(pageNum,pageSize);
                return PartialView(List);
            }
            else
                return PartialView(WebDB.Products.Where(s=>s.soldOut==false).OrderByDescending(s => s.NamePro).ToPagedList(pageNum,pageSize));
        }
        public PartialViewResult SelectCate()
        {
            Category se_cate = new Category();
            se_cate.ListCate = WebDB.Categories.ToList<Category>();
            return PartialView(se_cate);
        }
        public PartialViewResult SoldOutList(string _name, string category)
        {
            if (_name != null)
                return PartialView(WebDB.Products.Where(s => s.NamePro.Contains(_name)).ToList());

            else if (category != null)
                return PartialView(WebDB.Products.Where(s => (s.Category == category) || (s.Category2 == category)).ToList());
            else
                return PartialView(WebDB.Products.ToList());
        }
        public PartialViewResult Top4Bike()
        {
            return PartialView(WebDB.Products.Where(s => (s.Category == "BIKE") || (s.Category2 == "BIKE")).ToList());
        }
        public PartialViewResult Top4Shoes()
        {
            return PartialView(WebDB.Products.OrderByDescending(s => s.ProductID).Where(s => (s.Category == "GIAY") || (s.Category2 == "GIAY")).ToList());
        }
        public PartialViewResult Top4Product()
        {
            DBSportStoreEntities6 database = new DBSportStoreEntities6();

            List<OrderDetail> orderD = database.OrderDetails.ToList();
            List<Product> proList = database.Products.ToList();
            var query = from od in orderD
                        join p in proList on od.IDProduct equals p.ProductID into tbl
                        group od by new
                        {
                            category1 = od.Product.Category,
                            category2 = od.Product.Category2,
                            SoldOut = od.Product.soldOut,
                            idPro = od.IDProduct,
                            namePro = od.Product.NamePro,
                            imagePro = od.Product.ImagePro,
                            price = od.Product.Price
                        } into gr
                        orderby gr.Sum(s => s.Quantity) descending
                        select new ViewModel
                        {
                            soldOut = (bool)gr.Key.SoldOut,
                            IDPro = gr.Key.idPro,
                            NamePro = gr.Key.namePro,
                            ImgPro = gr.Key.imagePro,
                            pricePro = (decimal)gr.Key.price,
                            Sum_Quantity = gr.Sum(s => s.Quantity)
                        };
            return PartialView(query.Take(5).ToList());
        }
       
    }
}