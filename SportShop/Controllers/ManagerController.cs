using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportShop.Models;

namespace SportShop.Controllers
{
    public class ManagerController : Controller
    {
        DBSportStoreEntities6 database = new DBSportStoreEntities6();
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ProductList(string category)
        {
            if(category==null)
            {
                return PartialView(database.Products.OrderByDescending(s => s.NamePro));
            }
           else
            {
                return PartialView(database.Products.Where(s => s.Category == category));
            }
        }
        public ActionResult Edit(int id)
        {
            return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id,Product pro)
        {
            database.Entry(pro).State = System.Data.Entity.EntityState.Modified;
            
            if (pro.Quantity > 0)
                pro.soldOut = false;
            else
                pro.soldOut = true;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Product pro)
        {

            try
            {
                pro = database.Products.Where(s => s.ProductID == id).FirstOrDefault();
                database.Products.Remove(pro);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Delete Error, This data is using in other table");
            }
        }
        public ActionResult Create()
        {
            List<Category> list = database.Categories.ToList();
            ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate", "");
            Product pro = new Product();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Create(Product pro,FormCollection form)
        {
          
            List<Category> list = database.Categories.ToList();
           
            try
            {
                if (pro.UploadImg != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pro.UploadImg.FileName);
                    string extent = Path.GetExtension(pro.UploadImg.FileName);
                    fileName = fileName + extent;
                    pro.ImagePro = "/Content/img/" + fileName;
                    pro.UploadImg.SaveAs(Path.Combine(Server.MapPath("~/Content/img/"), fileName));

                }

                if (pro.Quantity > 0)
                {
                    pro.soldOut = false;
                }
                else
                {
                    pro.soldOut = true;
                }
                if (pro.Price < 0)
                {
                    ViewBag.priceError = "Giá sản phẩm phải lớn hơn hoặc bằng 0";
                    pro.Price = 0;
                }



                ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate", "--Select category--");

                database.Products.Add(pro);
                database.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(pro);
            }
               

        }
        public ActionResult OrderManager()
        {
            var model = (
                          from a in database.OrderProes
                          join b in database.OrderDetails on a.ID equals b.IDOrder
                          join p in database.Products on b.IDProduct equals p.ProductID
                          join user in database.AdminUsers on a.IDCus equals user.ID
                          orderby a.DateOrder descending
                          select new ViewModel()
                          {
                              phoneNumb = user.PhoneNumber,
                              gmail = user.gmail,
                              CustomerName =user.NameUser,
                              CustomerId = (int)a.IDCus,
                              namePro = p.NamePro,
                              address = a.AddressDeliverry,
                              dateOrder = (DateTime)a.DateOrder,
                              Quant = (int)b.Quantity,
                              pricePro = (int)b.UnitPrice

                          }
                        );
            return View(model);

        }
    }
}