﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;
    using System.ComponentModel.DataAnnotations;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ImagePro = "/Content/img/product.jpg";
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [NotMapped]
        public HttpPostedFileBase UploadImg { get; set; }

        public int ProductID { get; set; }
        [Display(Name ="Tên sản phẩm")]
        [Required(ErrorMessage ="Vui lòng nhập tên sản phẩm")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Tên sản phẩm phải lớn hơn 5 và bé hơn 50 ký tự")]
        public string NamePro { get; set; }
        [Display(Name = "Mô tả sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả sản phẩm")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Mô tả sản phẩm phải lớn hơn 0 và bé hơn 50 ký tự")]
        public string DecriptionPro { get; set; }
        [Required(ErrorMessage ="vui lòng chọn loại sản phẩm")]
        [Display(Name = "Loại sản phẩm")]
        public string Category { get; set; }
        [DisplayFormat(DataFormatString ="{0:0}")]
        [Display(Name = "Giá sản phẩm")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Required(ErrorMessage ="Vui lòng nhập giá sản phẩm")]
        public Nullable<decimal> Price { get; set; }
        [Display(Name = "Ảnh sản phẩm")]
        [Required(ErrorMessage ="Vui lòng chọn ảnh sản phẩm")]
        public string ImagePro { get; set; }
        public Nullable<bool> soldOut { get; set; }
        public Nullable<double> Size { get; set; }
        public string Category2 { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Required(ErrorMessage ="Vui lòng nhập số lượng sản phẩm ")]
        public Nullable<int> Quantity { get; set; }

        public List<Product> proList { get; set; }
        public virtual Category Category1 { get; set; }
        public virtual Category Category3 { get; set; }
        public virtual Category Category4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
