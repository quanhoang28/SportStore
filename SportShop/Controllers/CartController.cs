using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportShop.Models;

namespace SportShop.Controllers
{
    public class CartController : Controller
    {
        DBSportStoreEntities6 database = new DBSportStoreEntities6();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowCart()
        {
            if(Session["NameUser"]!=null)
            {
                if (Session["Cart"] == null)
                {
                    return View("EmptyCart");
                }
                Cart _cart = Session["Cart"] as Cart;
                return View(_cart);
            }
            return View("Index");
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart==null || Session["Cart"]==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public  ActionResult CheckOut (FormCollection form)
        {
           
            try
            {
                Cart cart = Session["Cart"] as Cart;
                OrderPro _order = new OrderPro();//Bang hoa don
                _order.DateOrder = DateTime.Now;
                _order.AddressDeliverry = form["AddressDelivarry"];
                _order.IDCus = (int)Session["ID"];
                AdminUser user = database.AdminUsers.FirstOrDefault(s => s.ID == _order.IDCus);

                database.OrderProes.Add(_order);
                foreach(var item in cart.Items)
                {
                    OrderDetail _order_Detail = new OrderDetail();
                    _order_Detail.IDOrder = _order.ID;
                    _order_Detail.IDProduct = item._product.ProductID;
                    _order_Detail.UnitPrice = (double)item._product.Price;
                    _order_Detail.Quantity = item._quantity;
                    _order_Detail.CustomerName = user.NameUser;
                    _order_Detail.PhoneNumber = user.PhoneNumber;
                   
                    database.OrderDetails.Add(_order_Detail);
                    foreach(var p in database.Products.Where(s=>s.ProductID==_order_Detail.IDProduct))
                    {
                        var update_quant_pro = p.Quantity - item._quantity;
                        p.Quantity = update_quant_pro;
                        if (p.Quantity == 0)
                        {
                            p.soldOut = true;
                        }
                        else
                            p.soldOut = false;
                    }
                }
                database.SaveChanges();
                cart.Clear_Cart();
                return RedirectToAction("CheckOutSuccess", "cart");
            }
            catch
            {
                return Content("Error checkout. Please check information of customer ");
            }
        }
        public ActionResult AddToCart(int id)
        {
            var _pro = database.Products.FirstOrDefault(s => s.ProductID == id);
            if(Session["NameUser"]!=null)
            {
                if (_pro != null)
                {
                    GetCart().Add_Product_Cart(_pro);
                }
                return RedirectToAction("ShowCart", "Cart");
            }

            return RedirectToAction("ShowCart", "Cart");

        }
        public ActionResult Update_Cart_Quantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["idPro"]);
            int _quantity = int.Parse(form["getQuantity"]);
            cart.Update_quantity(id_pro, _quantity);
            if (_quantity == 1)
                ViewBag.errorQuant = "Vui lòng nhập lại số lượng";


            return RedirectToAction("ShowCart", "Cart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowCart", "Cart");
        }
        public ActionResult CheckOutSuccess()
        {
            return View();
        }
        public PartialViewResult BagCart()
        {
            int total_quantity_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                total_quantity_item = cart.Total_quantity();
            ViewBag.QuantityCart = total_quantity_item;
            return PartialView("BagCart");
        }
    }
}