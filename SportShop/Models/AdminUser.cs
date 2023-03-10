//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AdminUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdminUser()
        {
            this.OrderProes = new HashSet<OrderPro>();
        }

        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int ID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [StringLength(50, MinimumLength = 5,ErrorMessage ="Tên đăng nhập phải lớn hơn 5 và bé hơn 50 ký tự")]
        [Display(Name = "Họ và tên")]
        public string NameUser { get; set; }
        [Display(Name = "Vị trí")]
        public string RoleUser { get; set; }
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(18, MinimumLength = 6, ErrorMessage = "Mật khẩu phải lớn hơn 6 và bé hơn 18 ký tự")]
        public string PasswordUser { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("PasswordUser", ErrorMessage = "Mật khẩu không khớp")]
        [DataType(DataType.Password, ErrorMessage = "Sai cú pháp, vui lòng nhập lại")]
        public string ConfirmPass { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Display(Name = "Số điện thoại")]
        [Phone(ErrorMessage ="Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập gmail")]
        [Display(Name = "Gmail")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Gmail không hợp lệ, vui lòng nhập lại")]
       
        public string gmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderPro> OrderProes { get; set; }
    }
}
