using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ghadir.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "ایمیل")]
        public string UserMail { get; set; }

        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "کلمه عبور وارد شده یکسان نیمباشد")]
        public string RePassword { get; set; }
    }
}