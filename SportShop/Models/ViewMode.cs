using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportShop.Models
{
    public class ViewModel
    {
        public bool soldOut { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string NamePro { get; set; }
        public string ImgPro { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        [Display(Name = "Giá sản phẩm")]
        public decimal pricePro { get; set; }
        public string Despro { get; set; }
        [System.ComponentModel.DataAnnotations.Key]
        public int? IDPro { get; set; }
        public decimal Total_money { get; set; }
        public Product product { get; set; }
        public string category { get; set; }
        public string category2 { get; set; }
        public OrderDetail orderDetail { get; set; }
        public IEnumerable<Product> ListProduct { get; set; }
        public int? Top5_Quantity { get; set; }
        public int? Sum_Quantity { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateOrder { get; set; }
        [Display(Name ="Địa chỉ")]
        public string address { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string namePro { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string CustomerName { get; set; }
        [Display(Name = "Số lượng")]
        public int Quant { get; set; }
        [Display(Name = "Số điện thoại")]
        public string phoneNumb { get; set; }
        [Display(Name = "gmail")]
        public string gmail { get; set; }
    }
}