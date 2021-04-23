using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ghadir.Models
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // خودمان به صورت دستی آی دی را وارد کنیم
        public int RoleId { get; set; }
        public string RoleName { get; set; }//برای نمایش نام نقش
        public string RoleInSystem { get; set; }//برای تعریف نقش ها از این مقدار استفاده می شوذ

        //برای کد فرست می باشد
        public int UserId { get; set; } //کلید خارجی Users

        //به این معنا که هر نقش می تواند چندین یوزر داشته باشد
        public virtual ICollection<User> Users { get; set; }
    }
}