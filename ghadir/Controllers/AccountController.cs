using ghadir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ghadir.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        MyContext db = new MyContext();
        // GET: Account
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                    return Redirect("~/Account/Crud");
                else
                    return Redirect("~/Home");
            }
            LoginViewModel lg = new LoginViewModel();

            ViewBag.login = lg;

            RegisterViewModel rg = new RegisterViewModel();

            ViewBag.register = rg;

            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginViewModel login, string submitValue)
        {
            if (User.Identity.IsAuthenticated)
                return Redirect(FormsAuthentication.DefaultUrl);

            if (submitValue == "ورود")
            {

                if (ModelState.IsValid)
                {
                    string Pass = FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");

                    FormsAuthentication.SetAuthCookie(login.UserMail, login.RememberMe);

                    return Redirect(FormsAuthentication.DefaultUrl);

                }


            }
            else
            {
                ModelState.Clear();
            }
            return View("Index", login);

        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register, string submitValue)
        {
            if (User.Identity.IsAuthenticated)
                return Redirect(FormsAuthentication.DefaultUrl);

            if (submitValue == "ثبت نام")
            {
                if (!db.Users.Any(u => u.UserMail == register.UserMail))
                {
                    if (ModelState.IsValid)
                    {

                        User user = new User()
                        {
                            UserMail = register.UserMail,
                            Password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password, "MD5"),
                            RoleId = 2

                        };
                        db.Users.Add(user);
                        db.SaveChanges();

                        return Redirect(FormsAuthentication.DefaultUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "خطایی رخ داده است لطفا موارد را دوباره چک نماید");
                }

            }
            else
            {
                ModelState.Clear();
            }
            return View("Index", register);


        }


        public ActionResult Logout() // متد خروج کاربر از حساب کاربریش
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing) //برای بسته شدن کانکتشن استرینگ حتما باید آخر هر کنترلر باید این متد را قرار دهید
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpGet]
        public ActionResult Crud()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crud(Product product)
        {
            if(ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index","Home",null);
            }
            
            return View();
        }
    }
}