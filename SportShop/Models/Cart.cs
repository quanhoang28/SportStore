using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportShop.Models
{
    public class CartItem
    {
        public Product _product { get; set; }
        public int _quantity { get; set; }
    }
    public class Cart
    {
        public int cartId { get; set; }
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        //them san pham vao gio hang
        public void Add_Product_Cart(Product _pro, int _quant = 1)
        {
            var item = Items.FirstOrDefault(s => s._product.ProductID == _pro.ProductID);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    _product = _pro,
                    _quantity = _quant
                });
            }
            else
            {
                item._quantity += _quant;
            }
        }

        //tong so luong hang
        public int Total_quantity()
        {
            return items.Sum(s => s._quantity);
        }

        //tong thanh tien
        
        public decimal Total_money()
        {
            var total = items.Sum(s => s._quantity * s._product.Price);
            return (decimal)total;
        }

        //Cap nhat so luong san pham cho gio hang
        
        public void Update_quantity(int _id, int _new_quant)
        {
            var item = items.Find(s => s._product.ProductID == _id);
            if (item != null)
            {
                if (items.Find(s => s._product.Quantity >= _new_quant) != null && _new_quant>0 )
                {
                    item._quantity = _new_quant;
                    
                }
                    

                else
                {
                    item._quantity = 1;
                    
                }    
                   
                
            }
               
        }

        //ham xoa san pham 
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._product.ProductID == id);

        }

        //ham xoa gio hang sau khi thanh toan
        public void Clear_Cart()
        {
            items.Clear();
        }
    }
}