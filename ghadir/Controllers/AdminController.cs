using ghadir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ghadir.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        MyContext db = new MyContext();
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        [HttpPost]
        public ActionResult Crud(string userName, string password)
        {
            ViewBag.UserName = userName;

            Admin Admin = new Admin { UserName = userName, Password = Convert.ToInt32(password) };

            if ( Admin.UserName == userName && Admin.Password == Convert.ToInt32(password))
            {
                return View();
            }

            //ViewBag.Admin = Admin;

            return View("ERRoR");
        }
    }
}